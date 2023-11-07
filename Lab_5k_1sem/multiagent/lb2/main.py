import random
from form import createForm

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
LABIRINT = None
MATRIX_LEN = len(R_MATRIX)
GAMMA = 0.8
STATE_NUM = None
FINAL_STATE = None

def isClose(xy1,xy2):
    if abs(xy1[0]-xy2[0]) == 1 and abs(xy1[1]-xy2[1]) == 0:
        return True
    if abs(xy1[0]-xy2[0]) == 0 and abs(xy1[1]-xy2[1]) == 1:
        return True
    return False

def getXYIndex(x):
    counter = 0
    for i_line in range(len(LABIRINT)):
        for j_item in range(len(LABIRINT[i_line])):
            if LABIRINT[i_line][j_item] == 0 or LABIRINT[i_line][j_item] == 2:
                if counter == x:
                    return (i_line,j_item)
                counter+=1

def makeRQMatrix():
    global R_MATRIX,Q_MATRIX,MATRIX_LEN,FINAL_STATE
    R_MATRIX = [[None for item in range(STATE_NUM)] for line in range(STATE_NUM)]
    for i in range(STATE_NUM):
        for j in range(STATE_NUM):
            xy_i = getXYIndex(i)
            xy_j = getXYIndex(j)
            if (isClose(xy_i,xy_j) or xy_i==xy_j) and LABIRINT[xy_j[0]][xy_j[1]] == 2:
                R_MATRIX[i][j] = STATE_NUM*STATE_NUM
                FINAL_STATE = j
            elif isClose(xy_i,xy_j):
                R_MATRIX[i][j] = 0
            else:
                R_MATRIX[i][j] = -1

    Q_MATRIX = [[item if item > 0 else 0 for item in line] for line in R_MATRIX]
    MATRIX_LEN = len(R_MATRIX)
    return


def printMatrix(matrix):
    for line in matrix:
        for item in line:
            print(item, " ", end="")
        print()


class Agent():
    prev_action = (None, None)

    def __init__(self, current_state):
        self.curState = current_state

    def move(self):
        allowed_move = []
        for state in range(0, MATRIX_LEN):
            if R_MATRIX[self.curState][state] != -1:
                allowed_move.append({
                    "next_state": state,
                    "weight": Q_MATRIX[self.curState][state]})

        random.shuffle(allowed_move)
        max_state = max(allowed_move, key=lambda x: x["weight"])

        if self.prev_action != (None, None):
            Q_MATRIX[self.prev_action[0]][
                    self.prev_action[1]] = R_MATRIX[self.prev_action[0]
                                                ][self.prev_action[1]] + int(GAMMA * max_state["weight"])

        self.prev_action = (self.curState, max_state["next_state"])
        self.curState = max_state["next_state"]

def move_consistently(num_agent):
    for i in range(num_agent):
        myAgent = Agent(random.randint(0, STATE_NUM-1))
        print("Агент -",i," Послідовність станів: ", myAgent.curState, "", end="")

        while FINAL_STATE is not None:
            myAgent.move()
            print(myAgent.curState, "", end="")
            if myAgent.curState == FINAL_STATE:
                break
        print()

def move_simultaneously(num_agent):    
    agent_list = [Agent(random.randint(0, STATE_NUM-1)) for _ in range(num_agent)]
    if FINAL_STATE is not None:
        while len(agent_list) > 0:
            for agent in agent_list:
                agent.move()
                if agent.curState == FINAL_STATE:
                    agent_list.remove(agent)

def main():
    global LABIRINT, STATE_NUM
    LABIRINT = createForm()
    STATE_NUM = sum([line.count(0) + line.count(2) for line in LABIRINT])
    makeRQMatrix()    
    move_simultaneously(100)
    printMatrix(Q_MATRIX)


if __name__ == "__main__":
    main()
