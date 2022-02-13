import math
import matplotlib.pyplot as plt
import numpy as np
import pandas as pd
from scipy.stats.mstats import trim
from scipy.stats.mstats import winsorize
from sklearn.impute import SimpleImputer

df = pd.DataFrame([["a", "x"],
                   [np.nan, "y"],
                   ["a", np.nan],
                   ["b", "y"]], dtype="category")
df2 = pd.read_csv("StudentsPerformance2.csv")

# print("-------------------drop-------------------")
# print(df.isnull().sum())
# for i in df.iterrows():
#     for j in i[1]:
#         if isinstance(j, float) and math.isnan(j):
#             df = df.drop([i[0]])
# print(df.isnull().sum())
# print("--------------------------------------")
#
# print("-------------------edit-nan-------------------")
# for j in df2.columns:
#     df2 = df2.replace({j: {np.nan : 0}})
# print(df2)
# print("--------------------------------------")

print("-------------------anomalies-------------------")
# data = np.random.randn(10000) * 20 + 20

df2.boxplot(by='gender', column='math score', grid=True)
plt.show()

df2['math score'].hist(bins=100)
plt.show()

# print(trim(df2['math score'], (0.1, 0.1), relative=True))

for i in ['math score', 'reading score', 'writing score']:
    print(trim(df2[i], (0.1, 0.1), relative=True))

print("--------------------------------------")

# imp = SimpleImputer(strategy="most_frequent")
# print(imp.fit_transform(df))
