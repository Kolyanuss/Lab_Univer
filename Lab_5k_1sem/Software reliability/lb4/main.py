import numpy as np

def main():
    arr_T = [0.5, 0.4, 0.5, 0.75, 0.2, 0.5, 0.3, 0.3, 0.1, 0.4]
    arr_count_err = [2, 0, 5, 3, 4, 1, 3, 2, 0, 1]
    T = 0.2
    I_t = 10000
    a = 3
    b = 4

    r = sum(arr_T)
    y = sum(arr_count_err) / r
    Ecr = sum(arr_count_err) / I_t

    ra = arr_T[a]
    ya = sum(arr_count_err[:a]) / sum(arr_T[:a])
    Ecra = arr_count_err[a] / I_t

    rb = arr_T[b]
    yb = sum(arr_count_err[:b]) / sum(arr_T[:b])
    Ecrb = arr_count_err[b] / I_t

    E_T = (I_t * ((ya * Ecra) - (yb * Ecrb))) / (ya - yb)
    C = ya / (E_T/I_t - Ecra)

    Er = E_T/I_t - Ecr
    R_t_r = np.exp(C * Er * T)
    
    print("Функція надійності (ймовірність безвідмовної роботи на інтервалі від 0 до",T,"год) =", R_t_r)

if __name__ == "__main__":
    main()