import random

SIZE_FIELD_X = 100
SIZE_FIELD_Y = 100
NUMBER_VICTIMS = 5000
NUMBER_PREDATOR = 200

ADULTHOOD_VICTIM = 3
REPRODUCTION_DELAY_VICTIM = 3
ADULTHOOD_PREDATOR = 9
REPRODUCTION_DELAY_PREDATOR = 9

PREDATOR_DYING_TIME = 4 # Хижак живе без їжі

FIELD = [[None for _ in range(SIZE_FIELD_X)] for _ in range(SIZE_FIELD_Y)]

class Fish:
    age = None
    x = None
    y = None
    reproduction_delay = None
    last_reproduction = None

    def __init__(self,x,y,reproduction_delay):
        self.x = x
        self.y = y
        self.reproduction_delay = reproduction_delay
        self.age = 0

    def __init__(self,x,y,reproduction_delay,age):
        self.x = x
        self.y = y
        self.reproduction_delay = reproduction_delay
        self.age = age


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
            if FIELD[x][y] is None:
                free_cell.append((x,y))
        if free_cell.count() == 0:
            return None,None
        return free_cell[random.randint(0,free_cell.count()-1)]
            
    def reproduce(self):
        if self.last_reproduction <= self.reproduction_delay:
            self.last_reproduction += 1 # little crutch)
            return # dont reproduce
        free_x,free_y = self.get_nearest_random_free_place()
        if free_x or free_y is None:
            return # dont reproduce
        FIELD[free_x][free_y] = self.__class__(free_x, free_y, self.reproduction_delay)
        self.last_reproduction = 0

    def move_to(self,x,y):
        FIELD[x][y] = self
        FIELD[self.x][self.y] = None
        self.x = x
        self.y = y

    def move(self):
        free_x,free_y = self.get_nearest_random_free_place()
        if free_x is None or free_y is None: # if no space - dont move
            return
        self.move_to(free_x,free_y)
        
    
class Victim(Fish):
    def print(self):
        print(1,end='')


class Predator(Fish):
    def print(self):
        print(2,end='')
    last_eat_time = 0

    def find_prey(self):
        preys = []
        for x,y in self.get_nearest_cells():           
            if FIELD[x][y].__class__ is Victim:
                preys.append((x,y))

        if preys.count() == 0:
            return None,None
        return preys[random.randint(0,preys.count()-1)]

    def move(self):
        to_x,to_y = self.find_prey()
        if to_x or to_y is None: # if no prey - just move
            super().move()
            self.last_eat_time += 1
        else: 
            self.move_to(to_x,to_y) # move to prey
            self.last_eat_time = 0 

        if self.last_eat_time >= PREDATOR_DYING_TIME:
            # die
            FIELD[self.x][self.y] = None

def get_free_cell():
    rnd_i = None
    rnd_j = None
    for _ in range(5): # max 5 random search
        rnd_i = random.randint(0, SIZE_FIELD_Y-1)
        rnd_j = random.randint(0, SIZE_FIELD_X-1)
        if FIELD[rnd_i][rnd_j] is None:
            return rnd_i,rnd_j
    # if failed random search - start sequential search
    for i in range(rnd_i,SIZE_FIELD_Y):
        for j in range(rnd_j,SIZE_FIELD_X):
            if FIELD[i][j] is None:
                return i,j
    for i in range(rnd_i,0,-1):
        for j in range(rnd_j,0,-1):
            if FIELD[i][j] is None:
                return i,j
    return None,None

def main():
    for _ in range(NUMBER_VICTIMS):
        x,y = get_free_cell() # debug this
        if x == None or y == None:
            break
        FIELD[x][y] = Victim(x,y,REPRODUCTION_DELAY_VICTIM,random.randint(0, ADULTHOOD_VICTIM))
    for _ in range(NUMBER_PREDATOR):
        x,y = get_free_cell()
        if x == None or y == None:
            break
        FIELD[x][y] = Predator(x,y,REPRODUCTION_DELAY_PREDATOR,random.randint(0, ADULTHOOD_PREDATOR))

    for line in FIELD:
        for item in line:
            if item is not None:
                item.print()
            else: print(0,end='')
        print("")
    # start main loop
    

    print("--------")


if __name__ == "__main__":
    main()