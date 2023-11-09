from pyspark.sql import SparkSession
from pyspark.sql.functions import col, udf, explode
from pyspark.sql.types import StringType, ArrayType
import os,sys

os.environ['PYSPARK_PYTHON'] = sys.executable
os.environ['PYSPARK_DRIVER_PYTHON'] = sys.executable

# функція повертатиме масив де перший елемент це ім'я автора, 
# а інші 3 елементи формуються за алгоритмом 3gram (check wiki)
def process_commit_message(commit_message:str):
    words = commit_message.split(" ")[:5]
    combinations = [words[i:i+3] for i in range(3)]
    return [" ".join(combination) for combination in combinations]

# Ініціалізація SparkSession
spark = SparkSession.builder.appName("lab1_main").getOrCreate()
# читаємо файл
df_git = spark.read.json("10K.github.jsonl")
# Відфільтруємо записи, де type = 'PushEvent'
filtered_df = df_git.filter(df_git['type'] == 'PushEvent')
# вибираємо з payload всі commits
df_commits = filtered_df.select(explode("payload.commits").alias("commit"))
# вибираємо в першу колонку датасету ім'я автора а в другу повідомлення
df_author_message = df_commits.select("commit.author.name", "commit.message")

result_df = df_author_message
for i in range(3):
    # добавляємо новий стовбець "3_grams" який буде заповнюватись з допомогою функції process_commit_message
    my_udf = udf(process_commit_message, ArrayType(StringType()))
    result_df = result_df.withColumn("3_grams_"+str(i), (my_udf(col("message")))[i])

result_df = result_df.drop("message")

# Виведення схеми та перших кількох рядків
result_df.printSchema()
result_df.show()

result_df.toPandas().to_csv("output_file.csv", index=False)