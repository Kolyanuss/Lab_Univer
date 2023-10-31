import random

R_MATRIX = [
    [-1, -1, -1, -1, 0, -1],
    [-1, -1, -1, 0, -1, 100],
    [-1, -1, -1, 0, -1, -1],
    [-1, 0, 0, -1, 0, -1],
    [0, -1, -1, 0, -1, 100],
    [-1, 0, -1, -1, 0, 100]
]
Q_MATRIX = [
    [0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 100],
    [0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 100],
    [0, 0, 0, 0, 0, 100]
]
MATRIX_LEN = len(R_MATRIX)
GAMMA = 0.8

def printQMatrix():
    for line in Q_MATRIX:
        for item in line:
            print(item," ",end="")
        print()

class Agent():
    prev_action = (None,None)

    def __init__(self, current_state):
        self.curState = current_state

    def move(self):
        allowed_move = []
        for state in range(0, MATRIX_LEN):
            if R_MATRIX[self.curState][state] != -1:
                allowed_move.append({
                    "next_state":state,
                    "weight":Q_MATRIX[self.curState][state]})

        random.shuffle(allowed_move)
        max_state = max(allowed_move, key=lambda x: x["weight"])
        
        if self.prev_action != (None,None):
            Q_MATRIX[self.prev_action[0]][self.prev_action[1]] = R_MATRIX[self.prev_action[0]][self.prev_action[1]] + int(GAMMA * max_state["weight"])
        
        self.prev_action = (self.curState,max_state["next_state"])
        self.curState = max_state["next_state"]


def main():
    for i in range(50):
        myAgent1 = Agent(random.randint(0,4))
        # myAgent1 = Agent(2)
        print("Послідовність станів: ",myAgent1.curState,"",end="")

        while True:
            myAgent1.move()
            print(myAgent1.curState,"",end="")
            if myAgent1.curState == 5:
                break
        print()

    printQMatrix()

if __name__ == "__main__":
    main()
