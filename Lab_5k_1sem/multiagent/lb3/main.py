import numpy as np
import matplotlib.pyplot as plt

history_data = np.array([10, 15, 13, 19, 14, 18, 17, 11])
# history_data = np.linspace(-np.pi, np.pi, 50) # sin point from -Pi to Pi
num_unknown_var = 4 # a0,a1,a2,a3
sne = [np.asarray([0]*(1+num_unknown_var))]*num_unknown_var # System of normal equations
agents = []

class Agent:
    def __init__(self, y, coef_a0, Fn1, Fn2):
        self.y = y
        self.coefs_a = [coef_a0, Fn1, Fn2, Fn1*Fn2]
        self.array = [np.asarray([self.y]+self.coefs_a)*self.coefs_a[i] for i in range(len(self.coefs_a))]

def create_agents():
    for i in range(2,len(history_data)):
        agents.append(Agent(history_data[i], 1, history_data[i-2], history_data[i-1]))

def make_sne():
    for i in range(len(sne)):
        for agent in agents:
            sne[i] = sne[i] + agent.array[i]

def mean_square_deviation(real, predicted):
    s = 0
    for i in range(len(real)):
        s += pow(real[i] - predicted[i], 2)
    return pow(s/len(real), 0.5)

def plot_graph(real_data, prediction):
    plt.figure(figsize=(10, 6))
    plt.plot(list(range(1,1+len(real_data))), real_data, label='Real data')
    plt.plot(list(range(3,3+len(prediction))), prediction, label='Prediction')
    plt.xlabel('time')
    plt.ylabel('value')
    plt.legend()
    plt.show()

def print_coefs(coef):
    print("System of normal equations:")
    for item in sne:
        print(f"{item[0]} = {item[1]}*a0 + {item[2]}*a1 + {item[3]}*a2 + {item[4]}*a3")

    print("\nCalculated coefs:")
    print("a0 =", coef[0])
    print("a1 =", coef[1])
    print("a2 =", coef[2])
    print("a3 =", coef[3])

def make_prediction(coef):
    predictions = []
    print("\nPredicted data:")
    for i in range(2,len(history_data)+1):
        prediction = coef[0] + coef[1]*history_data[i-2] + coef[2]*history_data[i-1] + coef[3]*history_data[i-2]*history_data[i-1]
        predictions.append(prediction)
        print(f"F{i+1} = {prediction}")
    return predictions

def main():
    create_agents()
    make_sne()
    B = np.array([sne[i][0] for i in range(len(sne))])
    A = np.array([sne[i][1:] for i in range(len(sne))])
    coef = np.linalg.solve(A, B)
    print_coefs(coef)

    real_data = history_data[2:]
    prediction = make_prediction(coef)

    print(f"\nMean square deviation: S = {mean_square_deviation(real_data, prediction)}")

    plot_graph(history_data,prediction)

if __name__ == "__main__":
    main()