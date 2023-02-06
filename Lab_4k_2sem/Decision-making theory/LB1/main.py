import re
VAR1 = ""
VAR2 = ""
fileName1 = "in1.txt"
fileName2 = "in2.txt"

while True:
    typeOfInput = input("""Виберіть тип вводу даних:
    1 - ввід з файлу
    2 - ввід вручну
    >""")
    if typeOfInput == "1":
        print("Дані будуть зчитані з файлів 'in1.txt' та 'in2.txt'")
        VAR1 = open(fileName1, "r").read()
        VAR2 = open(fileName2, "r").read()
        break
    elif typeOfInput == "2":
        myRange = input(
            "Введіть цифровий діапазон для першого бінарного відношення(наприклад 1 5):")
        rangeStart, rangeEnd = re.split("[ ,-]", myRange)
        VAR1 = [*range(int(rangeStart), int(rangeEnd))]
        myRange = input(
            "Введіть цифровий діапазон для другого бінарного відношення(наприклад 2 10):")
        rangeStart, rangeEnd = re.split("[ ,-]", myRange)
        VAR2 = [*range(int(rangeStart), int(rangeEnd))]
        break

    print("Виберіть один із двох запропонованих варіантів ввівши цифру 1 або 2 в терміналі")


print("Перше вхідне бінарне відношення:")
print(VAR1)
print("Друге вхідне бінарне відношення:")
print(VAR2)
