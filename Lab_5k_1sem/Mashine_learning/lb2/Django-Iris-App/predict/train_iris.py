# Load modules
from pandas import read_csv
from sklearn.model_selection import train_test_split
from sklearn.svm import SVC
import pandas as pd
from django.conf import settings

def train_new_model(pr1,pr2,pr3,pr4):
    # Load dataset
    df = pd.read_csv(settings.IRIS_CSV)

    x_param = []
    x_param.append('sepal_length') if pr1 == True else None
    x_param.append('sepal_width') if pr2 == True else None
    x_param.append('petal_length') if pr3 == True else None
    x_param.append('petal_width') if pr4 == True else None

    # Split into training data and test data
    X = df[x_param]
    y = df['classification']

    # Create training and testing vars, It’s usually around 80/20 or 70/30.
    # X_train, X_test, Y_train, Y_test = train_test_split(X, y, test_size=0.20, random_state=1)

    # Now we’ll fit the model on the training data
    model = SVC(gamma='auto')
    model.fit(X, y)

    # Pickle model 
    pd.to_pickle(model, settings.ML_MODEL)