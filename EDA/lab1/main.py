import math

import numpy as np
import pandas as pd
from sklearn.impute import SimpleImputer

df = pd.DataFrame([["a", "x"],
                   [np.nan, "y"],
                   ["a", np.nan],
                   ["b", "y"]], dtype="category")
df2 = pd.read_csv("StudentsPerformance2.csv")

print("-------------------drop-------------------")
print(df.isnull().sum())
for i in df.iterrows():
    for j in i[1]:
        if isinstance(j, float) and math.isnan(j):
            df = df.drop([i[0]])
print(df.isnull().sum())
print("--------------------------------------")

print("-------------------edit-nan-------------------")
for j in df2.columns:
    df2 = df2.replace({j: {np.nan : 0}})
print(df2)
print("--------------------------------------")

# imp = SimpleImputer(strategy="most_frequent")
# print(imp.fit_transform(df))
