import duckdb
import os
import glob
import shutil

FILE_PATH = "data/Electric_Vehicle_Population_Data.csv"
TABLE_NAME = "electric_cars"
REPORT_FOLDER = "report"

def create_table_with_csv(conn, csv_path:str):
    conn.execute(f"""
        CREATE TABLE {TABLE_NAME} AS 
        SELECT * 
        FROM read_csv_auto('{csv_path}')
    """)

def print_record(conn, num=3):
    df = conn.execute(f"SELECT * FROM {TABLE_NAME} LIMIT {num};").fetchdf()
    print(df)

def print_all_report_folder(conn):
    for file in glob.glob(os.path.join(REPORT_FOLDER, "*.parquet")):
        print("\nFile name: "+file)
        print(conn.execute(f"SELECT * FROM read_parquet('{file}')").fetchdf())

def calculate_analytics(conn):
    if os.path.exists(REPORT_FOLDER):
        shutil.rmtree(REPORT_FOLDER)
    os.makedirs(REPORT_FOLDER)

    # Кількість електромобілів у кожному місті
    conn.execute(f"""
        SELECT City, COUNT(*) as num_cars
        FROM {TABLE_NAME}
        GROUP BY City
    """).fetchdf().to_parquet(os.path.join(REPORT_FOLDER,'1city_cars.parquet'))

    # Знайдіть 3 найпопулярніші електромобілі
    conn.execute(f"""
        SELECT Make, COUNT(*) as num_cars
        FROM {TABLE_NAME}
        GROUP BY Make
        ORDER BY num_cars DESC
        LIMIT 3
    """).fetchdf().to_parquet(os.path.join(REPORT_FOLDER,'2popular_cars.parquet'))

    # Знайдіть найпопулярніший електромобіль у кожному поштовому індексі
    conn.execute(f"""
        SELECT "Postal Code" as PostalCode, Make, COUNT(*) as num_cars
        FROM {TABLE_NAME}
        GROUP BY PostalCode, Make
        QUALIFY ROW_NUMBER() OVER(PARTITION BY PostalCode ORDER BY num_cars DESC) = 1
    """).fetchdf().to_parquet(os.path.join(REPORT_FOLDER,'3popular_cars_by_postal_code.parquet'))

    # Кількість електромобілів за роками випуску
    conn.execute(f"""
        SELECT "Model Year" as Model_Year, COUNT(*) as num_cars
        FROM {TABLE_NAME}
        GROUP BY Model_Year
    """).fetchdf().to_parquet(os.path.join(REPORT_FOLDER,'4count_cars_by_year.parquet'))

def main():
    conn = duckdb.connect()
    create_table_with_csv(conn, FILE_PATH)
    print_record(conn)
    calculate_analytics(conn)
    print_all_report_folder(conn)
    conn.close()

if __name__ == "__main__":
    main()
