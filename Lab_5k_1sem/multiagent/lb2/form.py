import tkinter as tk
from tkinter import simpledialog

GRID = None
ROOT = None

def toggle_cell(row, col):
    if GRID[row][col].cget('bg') == 'white':
        GRID[row][col].configure(bg='black')
    elif GRID[row][col].cget('bg') == 'black':
        GRID[row][col].configure(bg='yellow')
    else:
        GRID[row][col].configure(bg='white')

def create_grid(rows, cols):
    global GRID
    GRID = [[None for _ in range(cols)] for _ in range(rows)]

    for row in range(rows):
        for col in range(cols):
            cell = tk.Label(ROOT, width=2, height=1, bg='white', relief=tk.RAISED)
            cell.grid(row=row, column=col)
            cell.bind('<Button-1>', lambda event, row=row, col=col: toggle_cell(row, col))
            GRID[row][col] = cell

    return GRID

def get_grid_size():
    rows = simpledialog.askinteger("Розмір матриці", "Введіть кількість рядків:")
    cols = simpledialog.askinteger("Розмір матриці", "Введіть кількість стовпців:")
    return rows, cols

def finish_input():
    ROOT.quit()

def createForm():
    global ROOT
    ROOT = tk.Tk()
    ROOT.title("Матриця")

    # Питаємо користувача про розмір матриці
    rows, cols = get_grid_size()

    GRID = create_grid(rows, cols)

    # Додаємо кнопку для завершення введення масиву
    finish_button = tk.Button(text="Завершити", command=finish_input)
    finish_button.grid(row=rows, columnspan=cols)

    ROOT.mainloop()

    result_arr = [[None for _ in range(cols)]for _ in range(rows)]
    for row in range(rows):
        for col in range(cols):
            if GRID[row][col].cget('bg') == 'white':
                result_arr[row][col] = 0
            elif GRID[row][col].cget('bg') == 'yellow':
                result_arr[row][col] = 2
            else:
                result_arr[row][col] = -1
    return result_arr

if __name__ == "__main__":
    createForm()