import shutil
from pyspark.sql import SparkSession
from pyspark.sql import Row
import zipfile
import csv
import os
from io import TextIOWrapper

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
    trips_duration = df["end_time"] - df["start_time"]
    print("+++++++++++++++++++++++++++++++++")
    trips_duration.show(5)
    return sum(trips_duration) / trips_duration

def get_trip_num_by_day(df):
    result = None

    return result

def get_top_start_station_by_month(df):
    result = None

    return result

def get_Men_or_women_drive_longer_on_average(df):
    result = None

    return result

def get_top10_age_by_longest_trip(df):
    result = None

    return result

def get_top10_age_by_shortest_trip(df):
    result = None

    return result

def collect_info_from_DF(df) -> tuple[int, dict[str,int], dict[int,str], list[tuple[str,str,str]], str, dict[str,list[int]]]:
    return (
        get_average_trip_duration(df),
        get_trip_num_by_day(df),
        get_top_start_station_by_month(df),
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
