import numpy as np
import matplotlib.pyplot as plt
import tensorflow as tf

mydata = np.array([10, 15, 13, 19, 14, 18, 17, 11])
# mydata = np.sin(np.linspace(-2*np.pi, 2*np.pi, 50)) # sin point from -Pi to Pi

def plot_multy_graph(real_data, *predictions):
    plt.figure(figsize=(10, 6))
    plt.plot(list(range(1,1+len(real_data))), real_data, label='Real data')
    i=0
    for prediction in predictions:
        plt.plot(list(range(3,3+len(prediction))), prediction, label='Prediction'+str(i))
        i+=1
    plt.xlabel('time')
    plt.ylabel('value')
    plt.legend()
    plt.show()

class Agent:
    def __init__(self, prediction_type, mydata):
        self.prediction_type = prediction_type
        self.history_data = mydata
        self.num_unknown_var = 4 # a0,a1,a2,a3
        self.sne = [np.asarray([0]*(1+self.num_unknown_var))]*self.num_unknown_var # System of normal equations
        self.calc_agents = []

    class Calcularot_Agent:
        def __init__(self, y, coef_a0, Fn1, Fn2, coef_a3):
            self.y = y
            self.coefs_a = [coef_a0, Fn1, Fn2, coef_a3]
            self.array = [np.asarray([self.y]+self.coefs_a)*self.coefs_a[i] for i in range(len(self.coefs_a))]

    def get_coef3(self,i):
        if self.prediction_type == 2:
            coef = pow(self.history_data[i-2],2)* self.history_data[i-1]
        elif self.prediction_type == 3:
            coef = self.history_data[i-2]* pow(self.history_data[i-1],2)
        else:
            coef = self.history_data[i-2]* self.history_data[i-1]
        return coef

    def create_calculator_agents(self):
        for i in range(2,len(self.history_data)):
            self.calc_agents.append(self.Calcularot_Agent(self.history_data[i], 1, self.history_data[i-2], self.history_data[i-1], self.get_coef3(i)))

    def make_sne(self):
        for i in range(len(self.sne)):
            for agent in self.calc_agents:
                self.sne[i] = self.sne[i] + agent.array[i]

    def mean_square_deviation(self, real, predicted):
        s = 0
        for i in range(len(real)):
            s += pow(real[i] - predicted[i], 2)
        return pow(s/len(real), 0.5)

    def print_coefs(self,coef):
        print("System of normal equations:")
        for item in self.sne:
            print(f"{item[0]} = {item[1]}*a0 + {item[2]}*a1 + {item[3]}*a2 + {item[4]}*a3")

        print("\nCalculated coefs:")
        print("a0 =", coef[0])
        print("a1 =", coef[1])
        print("a2 =", coef[2])
        print("a3 =", coef[3])

    def make_prediction(self,coef):
        predictions = []
        for i in range(2,len(self.history_data)+1):
            prediction = coef[0] + coef[1]*self.history_data[i-2] + coef[2]*self.history_data[i-1] + coef[3]*self.get_coef3(i)
            predictions.append(prediction)
            self.predictions = predictions
        return predictions

    def create_agents_predicions(self):
        self.create_calculator_agents()
        self.make_sne()
        B = np.array([self.sne[i][0] for i in range(len(self.sne))])
        A = np.array([self.sne[i][1:] for i in range(len(self.sne))])
        coef = np.linalg.solve(A, B)
        # self.print_coefs(coef)
        real_data = self.history_data[2:]
        prediction = self.make_prediction(coef)
        print(f"\nMean square deviation = {self.mean_square_deviation(real_data, prediction)}")
        return prediction[-1]

def make_prediction_with_NN(*predictions):
    x = []
    y = []
    for i in range(2,len(mydata)):
        pred1,pred2,pred3 = [*zip(*predictions)][:-1][i-2]
        x.append([mydata[i-2], mydata[i-1], pred1, pred2, pred3])
        y.append(mydata[i])
    x = np.asarray(x)
    y = np.asarray(y)

    model = tf.keras.Sequential()
    model.add(tf.keras.layers.Dense(units=1, activation=tf.keras.activations.relu, input_shape=(5,),
                                    kernel_initializer=tf.keras.initializers.GlorotUniform(seed=11) ))
    model.compile(optimizer=tf.keras.optimizers.RMSprop(0.001), loss=tf.keras.losses.mean_squared_error, metrics=[tf.keras.metrics.mean_squared_error])

    model.fit(x, y, epochs=300, verbose=False)
    pred1,pred2,pred3 = [*zip(*predictions)][-1]

    full_prediction = model.predict(x)
    full_prediction = np.append(full_prediction, model.predict(np.array([[ mydata[-2], mydata[-1], pred1, pred2, pred3]]))[0])
    print(full_prediction)
    return full_prediction

def main():
    ag1 = Agent(1,mydata)
    ag1.create_agents_predicions()
    ag2 = Agent(2,mydata)
    ag2.create_agents_predicions()
    ag3 = Agent(3,mydata)
    ag3.create_agents_predicions()
    full_NN_prediction = make_prediction_with_NN(ag1.predictions,ag2.predictions,ag3.predictions)

    plot_multy_graph(ag1.history_data,ag1.predictions,ag2.predictions,ag3.predictions,full_NN_prediction)


if __name__ == "__main__":
    main()