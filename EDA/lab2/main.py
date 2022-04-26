import math
import numpy as np
import pandas as pd
from scipy.stats import *
import matplotlib.pyplot as plt
from sklearn import preprocessing

df = pd.DataFrame([["a", "x"],
                   [np.nan, "y"],
                   ["a", np.nan],
                   ["b", "y"]], dtype="category")

df2 = pd.read_csv("StudentsPerformance.csv")

range_df = list(df2.select_dtypes(include=[np.number]).columns.values)


def zd1():
    global df2

    print("-------------------zd1-------------------")
    print("----------------------Describe:")
    print(df2.groupby(by="gender")[range_df].describe(percentiles=[]))

    print("----------------------Agg:")
    print(df2.groupby(by="gender")[range_df].agg([np.mean, np.std, np.min, np.max]))

    print("----------------------Sorted:")
    print(df2.groupby(by="gender")[range_df].agg([np.mean, np.std, np.min, np.max]).sort_values(by="gender",
                                                                                                ascending=False))
    print("-----------------------------------------")


def zd2(col1='gender', col2='race/ethnicity'):
    print("-------------------zd2-------------------")
    print(pd.crosstab(df2[col1], df2[col2]))
    print("-----------------------------------------")


def zd3(col='reading score'):
    print("-------------------zd3-------------------")
    rc_log = boxcox(df2[col], lmbda=0)
    rc_bc, bc_params = boxcox(df2[col])
    print(bc_params)
    df2['rc_bc'] = rc_bc
    df2['rc_log'] = rc_log

    fig2, (ax1, ax2, ax3) = plt.subplots(3, 1)
    fig2.set_size_inches(18, 9)

    # original review count histogram
    df2[col].hist(ax=ax1, bins=100)
    ax1.set_yscale('log')
    ax1.tick_params(labelsize=14)
    ax1.set_title('Review Counts Histogram', fontsize=14)
    ax1.set_xlabel('')
    ax1.set_ylabel('Occurrence', fontsize=14)

    # review count after log transform
    df2['rc_log'].hist(ax=ax2, bins=100)
    ax2.set_yscale('log')
    ax2.tick_params(labelsize=14)
    ax2.set_title('Log Transformed Counts Histogram', fontsize=14)
    ax2.set_xlabel('')
    ax2.set_ylabel('Occurrence', fontsize=14)

    # review count after Box-Cox transform
    df2['rc_bc'].hist(ax=ax3, bins=100)
    ax3.set_yscale('log')
    ax3.tick_params(labelsize=14)
    ax3.set_title('Box-Cox Transformed Counts Histogram', fontsize=14)
    ax3.set_xlabel('')
    ax3.set_ylabel('Occurrence', fontsize=14)

    # plt.figure(figsize=(10, 10))
    plt.show()

    # ---------------- Спосіб 2 ----------------
    fig2, (ax1, ax2, ax3) = plt.subplots(3, 1)
    fig2.set_size_inches(10, 10)

    prob1 = probplot(df2[col], dist=norm, plot=ax1)
    ax1.set_xlabel('')
    ax1.set_title('Probplot Normal')

    prob2 = probplot(df2['rc_log'], dist=norm, plot=ax2)
    ax2.set_xlabel('')
    ax2.set_title('Probplot after log transform')

    prob3 = probplot(df2['rc_bc'], dist=norm, plot=ax3)
    ax3.set_xlabel('')
    ax3.set_title('Probplot after Box-Cox transform')

    plt.show()

    print("-----------------------------------------")


def zd4(col1='math score', col2='reading score'):
    xs = df2[col1]
    ys = df2[col2]
    pd.DataFrame(np.array([xs, ys]).T).plot.scatter(0, 1, s=5, grid=True)
    plt.xlabel(col1)
    plt.ylabel(col2)
    plt.show()


def zd5(range_col=['gender', 'race/ethnicity', 'parental level of education']):
    enc = preprocessing.OrdinalEncoder()
    rezult = enc.fit_transform(df2[range_col])
    print(rezult)


pd.set_option('display.max_columns', 100)
pd.set_option('display.max_rows', 1000)

# zd1()
# zd2()
# zd3('reading score')
# zd4()
zd5()
