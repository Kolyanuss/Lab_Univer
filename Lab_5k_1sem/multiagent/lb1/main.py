SIZE_FIELD_X = 100
SIZE_FIELD_Y = 100
NUMBER_VICTIMS = 5000
NUMBER_PREDATOR = 200

ADULTHOOD_VICTIM = 3
REPRODUCTION_DELAY_VICTIM = 3
ADULTHOOD_PREDATOR = 9
REPRODUCTION_DELAY_PREDATOR = 9

PREDATOR_DYING_TIME = 4 # Хижак живе без їжі

FIELD = []

class Animal:
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

    def find_nearest_free_place(self):
        if FIELD[self.x][self.y+1] is None:
            return (self.x, self.y+1)
        if FIELD[self.x][self.y-1] is None:
            return (self.x, self.y-1)
        if FIELD[self.x+1][self.y] is None:
            return (self.x+1, self.y)
        if FIELD[self.x-1][self.y] is None:
            return (self.x-1, self.y)
        return None,None
            
    def reproduce(self, my_species):
        if self.last_reproduction <= self.reproduction_delay:
            self.last_reproduction += 1 # little crutch)
            return # dont reproduce
        free_x,free_y = self.find_nearest_free_place()
        if free_x or free_y is None:
            return # dont reproduce
        FIELD[free_x][free_y] = self.__class__(free_x, free_y, self.reproduction_delay)
        self.last_reproduction = 0

    def move():return


class Victim(Animal):    
    def move(self):
        free_x,free_y = self.find_nearest_free_place()
        if free_x or free_y is None: # if no space - dont move
            return
        FIELD[free_x][free_y] = self
        FIELD[self.x][self.y] = None
        self.x = free_x
        self.y = free_y


class Predator(Animal):
    last_eat_time = 0

    def find_prey(self):
        if FIELD[self.x][self.y+1].__class__ is Victim:
            return (self.x, self.y+1)
        if FIELD[self.x][self.y-1].__class__ is Victim:
            return (self.x, self.y-1)
        if FIELD[self.x+1][self.y].__class__ is Victim:
            return (self.x+1, self.y)
        if FIELD[self.x-1][self.y].__class__ is Victim:
            return (self.x-1, self.y)
        return None,None

    def move(self):
        to_x,to_y = self.find_prey()
        if to_x or to_y is None: # if no prey - just move
            self.last_eat_time += 1
            to_x,to_y = self.find_nearest_free_place()
            if to_x or to_y is None: # if no space - dont move
                return
        else: self.last_eat_time = 0

        FIELD[to_x][to_y] = self
        FIELD[self.x][self.y] = None
        self.x = to_x
        self.y = to_y

        if self.last_eat_time >= PREDATOR_DYING_TIME:
            # die
            FIELD[self.x][self.y] = None

        

def main():
    print("--------")

if __name__ == "__main__":
    main()