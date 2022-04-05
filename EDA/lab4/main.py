import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
from sklearn.metrics import accuracy_score
from sklearn.svm import SVC
from sklearn.model_selection import GridSearchCV, train_test_split, StratifiedKFold

df = pd.read_csv("StudentsPerformance.csv")

X = df.values[:, 5:8]
y = df.values[:, 0]

X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.3, random_state=100)

clf = SVC(kernel='linear', C=1000)
clf1 = clf.fit(X_train, y_train)

y_pred = clf1.predict(X_test)
print(accuracy_score(y_test, y_pred) * 100)


# plt.scatter(X[:, 0], X[:, 1], c=y, s=30, cmap=plt.cm.Paired)
#
# ax = plt.gca()
# xlim = ax.get_xlim()
# ylim = ax.get_ylim()
#
# xx = np.linspace(xlim[0], xlim[1], 30)
# yy = np.linspace(ylim[0], ylim[1], 30)
# YY, XX = np.meshgrid(yy, xx)
# xy = np.vstack([XX.ravel(), YY.ravel()]).T
# Z = clf.decision_function(xy).reshape(XX.shape)
#
# ax.contour(XX, YY, Z, colors='k', levels=[-1, 0, 1],
#            alpha=0.5, linestyles=['--', '-', '--'])
# ax.scatter(clf.support_vectors_[:, 0], clf.support_vectors_[:, 1],
#            s=100, linewidth=1, facecolors='none')
# plt.show()


# # -----

def plotSVC(title):
    global svc
    # create a mesh to plot in
    x_min, x_max = X[:, 0].min() - 1, X[:, 0].max() + 1
    y_min, y_max = X[:, 1].min() - 1, X[:, 1].max() + 1
    h = (x_max - x_min) / 100
    xx, yy = np.meshgrid(np.arange(x_min, x_max, h), np.arange(y_min, y_max, h))
    plt.subplot(1, 1, 1)
    xy = np.vstack([xx.ravel(), yy.ravel()]).T
    z = svc.decision_function(xy)
    z = z.reshape(xx.shape)
    plt.contourf(xx, yy, z, cmap=plt.cm.Paired, alpha=0.8)
    plt.scatter(X[:, 0], X[:, 1], c=y, cmap=plt.cm.Paired)
    plt.xlabel('Sepal length')
    plt.ylabel('Sepal width')
    plt.xlim(xx.min(), xx.max())
    plt.title(title)
    plt.show()
    pass


#
# kernels = ['linear', 'rbf', 'poly']
# for kernel in kernels:
#     svc = SVC(kernel=kernel).fit(X_train, y_train)
#     plotSVC('kernel = ' + str(kernel))
#
# gammas = [0.1, 1, 10, 100]
# for gamma in gammas:
#     svc = SVC(kernel='rbf', gamma=gamma).fit(X, y)
#     plotSVC('kernel = rbf, gamma(' + str(gamma) + ')')
#
# cs = [0.1, 1, 10, 100, 1000]
# for c in cs:
#     svc = SVC(kernel='rbf', C=c).fit(X, y)
#     plotSVC('kernel = rbf, C(' + str(c) + ')')
#
# degrees = [0, 1, 2, 3, 4, 5, 6]
# for degree in degrees:
#     svc = SVC(kernel='poly', degree=degree).fit(X, y)
#     plotSVC('kernel = poly, degree(' + str(degree) + ')')


def svc_param_selection(X, y):
    kernels = ['linear', 'rbf', 'poly']
    Cs = [0.001, 0.01, 0.1, 1, 10]
    gammas = [0.001, 0.01, 0.1, 1]
    param_grid = {'kernel': kernels, 'C': Cs, 'gamma': gammas}
    nfolds = StratifiedKFold(n_splits=3, shuffle=True, random_state=100)
    grid_search = GridSearchCV(SVC(), param_grid, cv=nfolds)
    # scoring="neg_log_loss",
    grid_result = grid_search.fit(X, y)
    svc = grid_result.best_params_
    # summarize results
    print("Best: %f using %s" % (grid_result.best_score_, grid_result.best_params_))
    # means = grid_result.cv_results_['mean_test_score']
    # stds = grid_result.cv_results_['std_test_score']
    # params = grid_result.cv_results_['params']
    # for mean, stdev, param in zip(means, stds, params):
    #     print("%f (%f) with: %r" % (mean, stdev, param))

    return svc


svc_param_selection(X_train, y_train)
# plotSVC(str(svc_param_selection(X_train, y_train)))
