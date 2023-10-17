from pyspark.sql import SparkSession
from pyspark.sql.functions import col, udf, explode, expr
from pyspark.sql.types import ArrayType, StringType

def process_commit_message(author_name, commit_message):
    words = commit_message.split(" ")[:5]
    combinations = [words[i:i+3] for i in range(3)]
    return [author_name]+[" ".join(combination) for combination in combinations]

# Ініціалізація SparkSession
spark = SparkSession.builder.appName("lab1_main").getOrCreate()

jsonl_file_path = "10K.github.jsonl"
df_git = spark.read.json(jsonl_file_path)

# Відфільтруємо записи, де type = 'PushEvent'
filtered_df = df_git.filter(df_git['type'] == 'PushEvent')
df_commits = filtered_df.select(explode("payload.commits").alias("commit"))
df_author_message = df_commits.select("commit.author.name", "commit.message")

generate_text_udf = udf(process_commit_message, ArrayType(StringType()))
# result_df = df_author_message.withColumn("3_grams", process_commit_message(col("name"), col("message")))
result_df = df_author_message.withColumn("3_grams", generate_text_udf("name","message"))

# Виведення схеми та перших кількох рядків
result_df.printSchema()
result_df.show()
