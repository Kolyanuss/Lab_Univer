import pandas as pd
import numpy as np
from sklearn.tree import DecisionTreeClassifier
from sklearn.metrics import accuracy_score

from sklearn.model_selection import train_test_split, StratifiedKFold
from sklearn.preprocessing import LabelEncoder
from sklearn.model_selection import GridSearchCV
import matplotlib.pyplot as plt
from matplotlib.pyplot import *

df = pd.read_csv("StudentsPerformance.csv")

range_df = list(df.select_dtypes(include=[np.number]).columns.values)

X = df.values[:, 5:8]
Y = df.values[:, 0]

X_train, X_test, y_train, y_test = train_test_split(X, Y, test_size=0.3, random_state=100)

clf_gini = DecisionTreeClassifier(criterion="gini", random_state=100,
                                  max_depth=3, min_samples_leaf=5)

clf_gini = clf_gini.fit(X_train, y_train)
print(clf_gini)

clf_entropy = DecisionTreeClassifier(criterion="entropy", random_state=100,
                                     max_depth=3, min_samples_leaf=5)
print(clf_entropy.fit(X_train, y_train))

y_pred = clf_gini.predict(X_test)
print(y_pred)

y_pred_en = clf_entropy.predict(X_test)
print(y_pred_en)

print("Accuracy is ")
print(accuracy_score(y_test, y_pred) * 100)

print("Accuracy 2 is ")
print(accuracy_score(y_test, y_pred_en) * 100)

# ------------------------------------------------------------

label_encoded_Y = LabelEncoder().fit_transform(Y)
min_samples_leaf = range(1, 20, 1)
max_features = ['auto', 'sqrt', 'log2']
min_samples_split = range(2, 20, 2)
max_depth = range(2, 10, 1)
dt = DecisionTreeClassifier(max_depth=3, max_features='auto', min_samples_split='int',
                            random_state=100, min_samples_leaf=min_samples_leaf)
param_grid = dict(max_depth=max_depth, min_samples_leaf=min_samples_leaf, min_samples_split=min_samples_split,
                  max_features=max_features)
kfold = StratifiedKFold(n_splits=3, shuffle=True, random_state=100)
grid_search = GridSearchCV(dt, param_grid, scoring="neg_log_loss", n_jobs=-1, cv=kfold, verbose=1)
grid_result = grid_search.fit(X, label_encoded_Y)
# summarize results
print("Best: %f using %s" % (grid_result.best_score_, grid_result.best_params_))
means = grid_result.cv_results_['mean_test_score']
stds = grid_result.cv_results_['std_test_score']
params = grid_result.cv_results_['params']
for mean, stdev, param in zip(means, stds, params):
    print("%f (%f) with: %r" % (mean, stdev, param))
