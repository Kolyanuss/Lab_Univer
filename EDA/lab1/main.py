import math
import matplotlib.pyplot as plt
import numpy as np
import pandas as pd
import seaborn as sns
from numpy import std, mean
from scipy.stats.mstats import trim
from scipy.stats.mstats import winsorize
from sklearn.impute import SimpleImputer

df = pd.DataFrame([["a", "x"],
                   [np.nan, "y"],
                   ["a", np.nan],
                   ["b", "y"]], dtype="category")

df2 = pd.read_csv("StudentsPerformance2.csv")

range_df = list(df2.select_dtypes(include=[np.number]).columns.values)


# range_df = ['math score', 'reading score', 'writing score']


def drop():
    global df
    print("-------------------drop-------------------")
    print(df.isnull().sum())
    for i in df.iterrows():
        for j in i[1]:
            if isinstance(j, float) and math.isnan(j):
                df = df.drop([i[0]])
    print(df.isnull().sum())
    print("--------------------------------------")


def simple_imputer_nan(df):
    imp = SimpleImputer(strategy="most_frequent")
    print(imp.fit_transform(df))


def replace_nan_to_zero():
    global df2
    print("-------------------edit-nan-------------------")
    for j in df2.columns:
        df2 = df2.replace({j: {np.nan: 0}})
    print(df2)
    print("--------------------------------------")


def fix_anomalies():
    print("-------------------anomalies-------------------")
    df2.boxplot(range_df)
    plt.show()
    df2['math score'].hist(bins=100)
    plt.show()

    for i in range_df:
        Q1 = df2[i].quantile([0.25]).values[0]
        Q3 = df2[i].quantile([0.75]).values[0]
        IQR = Q3 - Q1
        lower_limit = Q1 - (1.5 * IQR)
        upper_limit = Q3 + (1.5 * IQR)
        df2[i] = trim(df2[i], (lower_limit, upper_limit))

    df2.boxplot(range_df)
    plt.show()
    df2['math score'].hist(bins=75)
    plt.show()
    print("--------------------------------------")


def HeatMap(df):
    colours = ['#000099', '#ffff00']
    sns.heatmap(df[df.columns].isnull(), cmap=sns.color_palette(colours))
    plt.show()


def ending():
    global df2
    # центрування
    print("центрування")
    for i in range_df:
        avg = df2[i].mean()
        dic = dict()
        for j in df2[i]:
            dic.update({j: j - avg})
        df2 = df2.replace({i: dic})
    print(df2)

    # нормування
    print("нормування")
    for i in range_df:
        mystd = df2[i].std()
        dic = dict()
        for j in df2[i]:
            dic.update({j: j / mystd})
        df2 = df2.replace({i: dic})
    print(df2[range_df])

    # дисперсія
    print("дисперсія та сума всіх елементів")
    for i in range_df:
        print(i, end='\t\t')
        print(df2[i].var(), end='\t\t')
        print(df2[i].sum())


HeatMap(df2)
drop()
df3 = df2
simple_imputer_nan(df3)
replace_nan_to_zero()
fix_anomalies()
ending()
