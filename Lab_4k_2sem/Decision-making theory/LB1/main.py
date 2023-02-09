import re
VAR1 = ""
VAR2 = ""
fileInName1 = "in1.txt"
fileInName2 = "in2.txt"
fileOutName1 = "out1.txt"
fileOutName2 = "out2.txt"


def binaryAction1(x, y):
    result = x  # temp
    return result


def binaryAction2(x, y):
    result = y  # temp
    return result


def readFile(fileInName):
    text = open(fileInName, "r").read()
    lines = text.splitlines()
    result = []
    for line in lines:
        result.append(list(map(int, line.split(" "))))
    return result


def convertArrayToReadAbleStr(arr):
    result = ""
    for line in arr:
        for item in line:
            result += str(item)+" "
        result += "\n"
    return result


while True:
    typeOfInput = input("""Виберіть тип вводу даних:
    1 - ввід з файлу
    2 - ввід вручну(тимчасово не працює)
    >""")
    if typeOfInput == "1":
        print(
            f"Дані будуть зчитані з файлів '{fileInName1}' та '{fileInName2}'")
        VAR1 = readFile(fileInName1)
        VAR2 = readFile(fileInName2)
        break
    elif typeOfInput == "2":
        # myRange = input(
        #     "Введіть цифровий діапазон для першого бінарного відношення(наприклад 1 5):")
        # rangeStart, rangeEnd = re.split("[ ,-]", myRange)
        # VAR1 = [*range(int(rangeStart), int(rangeEnd))]
        # myRange = input(
        #     "Введіть цифровий діапазон для другого бінарного відношення(наприклад 2 10):")
        # rangeStart, rangeEnd = re.split("[ ,-]", myRange)
        # VAR2 = [*range(int(rangeStart), int(rangeEnd))]
        break

    print("Виберіть один із двох запропонованих варіантів ввівши цифру 1 або 2 в терміналі")

print("Перше вхідне бінарне відношення:")
print(convertArrayToReadAbleStr(VAR1))
print("Друге вхідне бінарне відношення:")
print(convertArrayToReadAbleStr(VAR2))

while True:
    typeAction = input("""Виберіть дію:
    1 - Варіант 1
    2 - Варіант 2
    3 - Завершення роботи
    >""")

    if typeAction == "1":
        result = convertArrayToReadAbleStr(binaryAction1(VAR1, VAR2))
        print(
            f"Дію успішно виконано, результат буде записаний у файл '{fileOutName1}'")
        file = open(fileOutName1, "w")
        file.write(result)
        file.close()

    elif typeAction == "2":
        result = convertArrayToReadAbleStr(binaryAction2(VAR1, VAR2))
        print(
            f"Дію успішно виконано, результат буде записаний у файл '{fileOutName2}'")
        file = open(fileOutName2, "w")
        file.write(result)
        file.close()

    elif typeAction == "3":
        print("Завершення роботи програми!")
        break

    else:
        print("Виберіть один із двох запропонованих варіантів ввівши цифру 1,2 або 3 в терміналі")