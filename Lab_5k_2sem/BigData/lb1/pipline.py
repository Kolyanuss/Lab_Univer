import time
import tensorflow as tf
from sklearn.decomposition import TruncatedSVD


class myReducePipline():
    lat_dim_ae = 50
    lat_dim_svd = 80

    def __init__(self) -> None:
        self.create_ae()
        self.create_svd()

    def create_ae(self):
        inputs = tf.keras.layers.Input(shape=(784,))
        encoded = tf.keras.layers.Dense(128, activation='relu')(inputs)
        encoded = tf.keras.layers.Dense(self.lat_dim_ae, activation='relu')(encoded)
        decoded = tf.keras.layers.Dense(128, activation='relu')(encoded)
        decoded = tf.keras.layers.Dense(784, activation='sigmoid')(decoded)
        self.autoencoder = tf.keras.Model(inputs, decoded)
        self.autoencoder.compile(optimizer='adam', loss='mse')

    def create_svd(self):
        self.svd = TruncatedSVD(n_components=self.lat_dim_svd)

    def fit_ae_model(self, x_train, x_test):
        self.autoencoder.fit(x_train, x_train, epochs=10)
        x_train_ae = self.autoencoder.predict(x_train)
        x_test_ae = self.autoencoder.predict(x_test)
        return x_train_ae, x_test_ae

    def fit_svd_model(self, x_train, x_test):
        self.svd.fit(x_train)
        x_train_svd = self.svd.transform(x_train)
        x_test_svd = self.svd.transform(x_test)
        return x_train_svd, x_test_svd

    def get_svd_inverse_transform(self, x):
        return self.svd.inverse_transform(x)

    def run_pipeline(self, x_train_flat, x_test_flat):
        # AE
        start_time = time.time()
        x_train, x_test = self.fit_ae_model(x_train_flat, x_test_flat)
        AE_train_time = time.time() - start_time

        # SVD
        start_time = time.time()
        x_train, x_test = self.fit_svd_model(x_train, x_test)
        svd_train_time = time.time() - start_time

        print("AE create + train time: ", AE_train_time, " sec")
        print("SVD create + train time:", svd_train_time, " sec")

        return x_train, x_test
