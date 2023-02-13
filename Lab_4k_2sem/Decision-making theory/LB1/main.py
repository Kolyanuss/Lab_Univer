import re
VAR1 = []
VAR2 = []
fileInName1 = "in1.txt"
fileInName2 = "in2.txt"
fileOutName1 = "out1.txt"
fileOutName2 = "out2.txt"


def binaryAction1(x, y):
    result = []
    for itemX in x:
        existPair = False
        for itemY in y:
            if itemX == itemY:
                existPair = True
                break
        if not existPair:
            result.append(itemX)
    print("Дію (Різниця) успішно виконано")
    return result


def binaryAction2(x, y):
    result = "Перетин "
    isEmpty = True
    for itemX in x:
        for itemY in y:
            if itemX == itemY:
                isEmpty = False
                result += "не "
                break
        if not isEmpty:
            break
    result += "порожній!"
    print("Дію (Чи порожній перетин) успішно виконано")
    return result


def readFile(fileInName):
    text = open(fileInName, "r").read()
    lines = text.splitlines()
    result = []
    if lines[0].count(",") > 0:
        for line in lines:
            result.append(list(map(int, line.split(","))))
    else:
        for line in lines:
            result.append(list(map(int, line.split(" "))))
        result = arrToRelation(result)
    return result


def printArr(arr):
    for line in arr:
        print(line)

def arrToRelation(arr):
    result = []
    for i in range(0, len(arr)):
        vector = arr[i]
        for j in range(0, len(vector)):
            if vector[j] == 1:
                result.append([i+1,j+1])
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
        myRange = input(
            "Введіть множину для першого бін. відношення(наприклад: 1-5)>")
        rangeStart, rangeEnd = re.split("[ ,-]", myRange)
        set = [*range(int(rangeStart), int(rangeEnd))]
        for item1 in set:
            for item2 in set:
                VAR1.append([item1,item2])

        myRange = input(
            "Введіть множину для другого бін. відношення(наприклад: 2 4)>")
        rangeStart, rangeEnd = re.split("[ ,-]", myRange)
        set = [*range(int(rangeStart), int(rangeEnd))]
        for item1 in set:
            for item2 in set:
                VAR2.append([item1,item2])
        break

    print("Виберіть один із двох запропонованих варіантів ввівши цифру 1 або 2 в терміналі")

print("Перше вхідне бінарне відношення:")
printArr(VAR1)
print("Друге вхідне бінарне відношення:")
printArr(VAR2)

while True:
    typeAction = input("""Виберіть дію:
    1 - Різниця
    2 - Чи порожній перетин?
    3 - Завершення роботи
    >""")

    if typeAction == "1":
        result = str(binaryAction1(VAR1, VAR2))
        print(f"Результат записаний у файл '{fileOutName1}'")
        file = open(fileOutName1, "w")
        file.write(result)
        file.close()

    elif typeAction == "2":
        result = binaryAction2(VAR1, VAR2)
        print(f"Дію успішно виконано, результат буде записаний у файл '{fileOutName2}'")
        file = open(fileOutName2, "w")
        file.write(result)
        file.close()

    elif typeAction == "3":
        print("Завершення роботи програми!")
        break

    else:
        print("Виберіть один із двох запропонованих варіантів ввівши цифру 1,2 або 3 в терміналі")
