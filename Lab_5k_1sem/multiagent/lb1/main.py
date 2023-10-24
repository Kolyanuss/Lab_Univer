import random
import matplotlib.pyplot as plt
from matplotlib.colors import ListedColormap

SIZE_FIELD_X = 100
SIZE_FIELD_Y = 100
NUMBER_VICTIMS = 5000
NUMBER_PREDATOR = 200

ADULTHOOD_VICTIM = 3
REPRODUCTION_DELAY_VICTIM = 3
ADULTHOOD_PREDATOR = 9
REPRODUCTION_DELAY_PREDATOR = 9

PREDATOR_DYING_TIME = 4 # Хижак живе без їжі

NUM_EVOLUTION = 300
FIELD = [[None for _ in range(SIZE_FIELD_X)] for _ in range(SIZE_FIELD_Y)]

class Fish:
    age = None
    x = None
    y = None
    reproduction_delay = None
    last_reproduction = None


    def __init__(self,x,y,reproduction_delay,age): # for random create
        self.x = x
        self.y = y
        self.reproduction_delay = reproduction_delay
        self.age = age
        self.last_reproduction = self.age

    def get_nearest_cells(self):
        nearest_cells = []
        if self.y == SIZE_FIELD_Y-1:
            nearest_cells.append((self.x, 0))
        else:
            nearest_cells.append((self.x, self.y+1))

        if self.y == 0:
            nearest_cells.append((self.x, SIZE_FIELD_Y-1))
        else:
            nearest_cells.append((self.x, self.y-1))

        if self.x == SIZE_FIELD_X-1:
            nearest_cells.append((0, self.y))
        else:
            nearest_cells.append((self.x+1, self.y))

        if self.x == 0:
            nearest_cells.append((SIZE_FIELD_X-1, self.y))
        else:
            nearest_cells.append((self.x-1, self.y))

        return nearest_cells

    def get_nearest_random_free_place(self):
        free_cell = []
        for x,y in self.get_nearest_cells():
            if FIELD[y][x] is None:
                free_cell.append((x,y))
        if len(free_cell) == 0:
            return None,None
        return free_cell[random.randint(0,len(free_cell)-1)]
            
    def reproduce(self):
        self.last_reproduction += 1
        if self.last_reproduction >= self.reproduction_delay:
            free_x,free_y = self.get_nearest_random_free_place()
            if free_x is not None and free_y is not None:
                FIELD[free_y][free_x] = self.__class__(free_x, free_y, self.reproduction_delay,0)
                self.last_reproduction = 0

    def move_to(self,new_x,new_y):
        FIELD[new_y][new_x] = self
        FIELD[self.y][self.x] = None
        self.x = new_x
        self.y = new_y

    def move(self):
        free_x,free_y = self.get_nearest_random_free_place()
        if free_x is not None and free_y is not None:
            self.move_to(free_x,free_y)
        
    
class Victim(Fish):
    None

class Predator(Fish):
    last_eat_time = 0

    def find_prey(self):
        preys = []
        for x,y in self.get_nearest_cells():           
            if FIELD[y][x].__class__ is Victim:
                preys.append((x,y))

        if len(preys) == 0:
            return None,None
        return preys[random.randint(0,len(preys)-1)]

    def move(self):
        to_x,to_y = self.find_prey()
        if to_x is not None and to_y is not None: 
            self.move_to(to_x,to_y) # move to prey
            self.last_eat_time = 0 
        else: # if no prey - just move
            super().move()
            self.last_eat_time += 1

        if self.last_eat_time >= PREDATOR_DYING_TIME:
            FIELD[self.y][self.x] = None # die

def get_random_free_cell():
    rnd_i = None
    rnd_j = None
    for _ in range(10): # max 10 random search
        rnd_i = random.randint(0, SIZE_FIELD_Y-1)
        rnd_j = random.randint(0, SIZE_FIELD_X-1)
        if FIELD[rnd_i][rnd_j] is None:
            return rnd_j,rnd_i
    # if failed random search - start sequential search
    for i in range(0,SIZE_FIELD_Y):
        for j in range(0,SIZE_FIELD_X):
            if FIELD[i][j] is None:
                return j,i
    return None,None

def get_victim_num():
    num = 0
    for line in FIELD:
        for fish in line:
            if fish.__class__ == Victim:
                num+=1
    return num

def get_predator_num():
    num = 0
    for line in FIELD:
        for fish in line:
            if fish.__class__ == Predator:
                num+=1
    return num

def plot_graph(x,y1,y2):
    plt.plot(x, y1,label='жертви')
    plt.plot(x, y2,label='хижаки')

    # Додавання заголовка та підписів до осей
    plt.title('Результат еволюції')
    plt.xlabel('ксть ітерацій еволюції')
    plt.ylabel('Чисельність')
    plt.legend()

    # Відображення графіка
    plt.show()

def convert_myclass_to_int():
    return [[(1 if item.__class__ == Victim else (2 if item.__class__ == Predator else 0)) for item in line] for line in FIELD]

def plot_items():
    colors = ListedColormap(['white', 'green', 'red'])
    plt.imshow(convert_myclass_to_int(), cmap=colors)
    plt.colorbar()
    plt.show()

def main():
    # init
    # i = 0
    # while i < NUMBER_VICTIMS:
    for i in range(NUMBER_VICTIMS):
        x,y = get_random_free_cell()
        if x == None or y == None:
            print("No more space for Victim ",i)
            break
        FIELD[y][x] = Victim(x,y,REPRODUCTION_DELAY_VICTIM,random.randint(0, ADULTHOOD_VICTIM))        
        # i+=1
    
    for i in range(NUMBER_PREDATOR):
        x,y = get_random_free_cell()
        if x == None or y == None:
            print("No more space for Predator ",i)
            break
        FIELD[y][x] = Predator(x,y,REPRODUCTION_DELAY_PREDATOR, random.randint(0, ADULTHOOD_PREDATOR))
    
    plot_items()
    
    list_victim_num = [get_victim_num()]
    list_predator_num = [get_predator_num()]
    i=0
    # start main loop
    while i < NUM_EVOLUTION:
        for line in FIELD:
            for fish in line:
                if fish is not None:
                    fish.move()
        for line in FIELD:
            for fish in line:
                if fish is not None:
                    fish.reproduce()

        list_victim_num.append(get_victim_num())
        list_predator_num.append(get_predator_num())
        
        i+=1
    
    plot_items()
    plot_graph(range(NUM_EVOLUTION+1), list_victim_num, list_predator_num)


if __name__ == "__main__":
    main()