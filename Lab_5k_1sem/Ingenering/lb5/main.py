from pyspark.sql import SparkSession
from pyspark.sql import Row
from pyspark.sql import functions as F
from io import TextIOWrapper
import zipfile
import csv
import os
import shutil

SPARK = None

def create_sparkSession():
    global SPARK
    SPARK = SparkSession.builder.appName("Exercise6").enableHiveSupport().getOrCreate()

def get_zip_file_paths(data_location):
    zip_file_paths = []
    for root, dirs, files in os.walk(data_location):
        zip_file_paths.extend([os.path.join(root, file) for file in files if file.endswith(".zip")])
    return zip_file_paths

def get_csv_files(zip_file_paths):
    csv_files = []
    for zip_file_path in zip_file_paths:
        with zipfile.ZipFile(zip_file_path, 'r') as zip_ref:
            all_files = zip_ref.namelist()
            csv_file_paths = [file for file in all_files if file.endswith('.csv') and not file.count("__MACOSX")]
            for csv_file_name in csv_file_paths:
                csv_files.append(zip_ref.open(csv_file_name))
    return csv_files

def make_DF_from_file(file):
    # Читаємо вміст файлу у пам'ять
    reader = csv.reader(TextIOWrapper(file))
    header = next(reader)
    rows = [Row(*line) for line in reader]
    return SPARK.createDataFrame(rows, header)

def get_average_trip_duration(df):
    df2 = df.withColumn("time_diff", F.col("end_time").cast("long") - F.col("start_time").cast("long"))    
    return df2.agg(F.avg("time_diff")).first()[0]

def get_trips_per_day(df):
    df2 = df.withColumn("start_date", F.to_date(F.col("start_time")))
    df2 = df2.groupBy("start_date").count()
    rows = df2.select("start_date", "count").collect()
    return {(str(row["start_date"]), row["count"]) for row in rows}

def get_top_start_station_by_month(df):
    df = df.withColumn("month", F.month(F.col("start_time")))
    station_counts = df.groupBy("month", "from_station_name").count()
    popular_stations = station_counts.groupBy("month").agg(F.max("count").alias("max_count"))
    # result = popular_stations.join(station_counts, (station_counts.month == popular_stations.month) & (station_counts.count == popular_stations.max_count))
    station_counts.createOrReplaceTempView("station_counts")
    popular_stations.createOrReplaceTempView("popular_stations")
    df_res = SPARK.sql("""
        SELECT sc.month, sc.from_station_name, sc.count
        FROM station_counts sc
        JOIN (
            SELECT month, max_count
            FROM popular_stations
        ) ps ON sc.month = ps.month AND sc.count = ps.max_count
    """)
    rows = df_res.select("month", "from_station_name").collect()
    return {(row["month"], row["from_station_name"]) for row in rows}

def get_top3_station_4every_week(df):
    return

def get_Men_or_women_drive_longer_on_average(df):
    df2 = df.groupBy("gender").count()
    return df2.orderBy(F.desc("count")).select("gender").first()["gender"]

def get_top10_age_by_longest_trip(df):
    result = None

    return result

def get_top10_age_by_shortest_trip(df):
    result = None

    return result

def collect_info_from_DF(df) -> tuple[int, dict[str,int], dict[int,str], list[tuple[str,str,str]], str, dict[str,list[int]]]:
    df = df.withColumn("start_time", F.to_timestamp(F.col("start_time"), 'yyyy-MM-dd HH:mm:ss'))
    df = df.withColumn("end_time", F.to_timestamp(F.col("end_time"), 'yyyy-MM-dd HH:mm:ss'))
    return (
        get_average_trip_duration(df),
        get_trips_per_day(df),
        get_top_start_station_by_month(df),
        get_top3_station_4every_week(df),
        get_Men_or_women_drive_longer_on_average(df),
        {"longest" : get_top10_age_by_longest_trip(df),
         "shortest" : get_top10_age_by_shortest_trip(df)}
    )

def make_csv_reports(info):
    print("-----------------------------------", info)
    folder = 'reports'
    if os.path.exists(folder):
        shutil.rmtree(folder)
    os.makedirs(folder)
    # creating report code

def main():
    create_sparkSession()
    data_location = "data"
    zip_file_paths = get_zip_file_paths(data_location)
    csv_files = get_csv_files(zip_file_paths)

    for file in csv_files:        
        file_name = file.name
        df = make_DF_from_file(file)
        file.close()
        print(f"Data from {file_name}:")
        df.show(5)
        info = collect_info_from_DF(df)
        make_csv_reports(info)
        break

    print("End")


if __name__ == "__main__":
    main()
