from tkinter import filedialog
import math
import ast
import javalang

EXTENSIONS = ['.py', '.java']

def chooseFiles():
    chosen_file_paths = filedialog.askopenfilenames(title='Виберіть файли програм які містять програмний код',
                                                  filetypes=[('файли з кодом', EXTENSIONS)])
    if chosen_file_paths:
        print("Ви вибрали:", chosen_file_paths)
        return chosen_file_paths
    else:
        print("Ви нічого не вибрали.")


def parse_py_file(file):
    code = file.read()
    tree = ast.parse(code)

    dict_constructs = 0
    subroutines = 0
    variable_arrays = 0
    local_labels = 0
    constants = 0

    for node in ast.walk(tree):
        if isinstance(node, ast.FunctionDef):
            subroutines += 1

        if isinstance(node, ast.Dict) or isinstance(node, ast.Set):
            dict_constructs += 1

        if isinstance(node, ast.List) or isinstance(node, ast.Tuple):
            variable_arrays += 1

        if isinstance(node, ast.Name) and not isinstance(node.ctx, ast.Load):
            local_labels += 1

        if isinstance(node, ast.Constant):
            constants += 1

    return {
        "dict_constructs": dict_constructs,
        "subroutines": subroutines,
        "variable_arrays": variable_arrays,
        "local_labels": local_labels,
        "constants": constants
    }

def parse_java_file(file):
    code = file.read()
    tree = javalang.parse.parse(code)

    dict_constructs = 0
    subroutines = 0
    variable_arrays = 0
    local_labels = 0
    constants = 0

    for path, node in tree:
        if isinstance(node, javalang.tree.CompilationUnit):
            subroutines += 1

        if isinstance(node, javalang.tree.DictionaryInitializer):
            dict_constructs += 1

        if isinstance(node, javalang.tree.ArrayInitializer):
            variable_arrays += 1

        if isinstance(node, javalang.tree.Statement):
            if 'break' in str(node):
                local_labels += 1

        if isinstance(node, javalang.tree.ConstantDeclaration):
            constants += 1

    return {
        "dict_constructs": dict_constructs,
        "subroutines": subroutines,
        "variable_arrays": variable_arrays,
        "local_labels": local_labels,
        "constants": constants
    }


def calculate_error(input: dict[str,int]) -> float:
    n_sk = input["dict_constructs"] # кількість використовуваних словникових конструкцій
    n_pp = input["subroutines"] # кількість підпрограм
    n_mp = input["variable_arrays"] # кількість масивів змінних
    n_met = input["local_labels"] # кількість локальних міток
    n_k = input["constants"] # кількість констант
    n1 = n_sk + n_pp # число операцій
    n2 = n_mp + n_met + n_k # число операндів
    n = n1 + n2 # словник
    a = n1 * math.log2(n1) + n2 * math.log2(n2) # теоретична довжина програми
    v = a * math.log2(n) # обсяг програми, що спостерігається
    vy = 3000 # питомий обсяг програми, рівний середньому обсягу програми, що припадає на один дефект
    return v / vy

def concat(x1,x2:dict[str, int]):
    if len(x1) == 0:
        x1 = x2
    else:
        for key in x2.keys():
            x1[key] += x2[key]
    return x1

def main():
    chosen_file_paths = chooseFiles()
    if chosen_file_paths is None:
        exit(0)
    parsed_data = {}
    for chosen_file_path in chosen_file_paths:
        with open(chosen_file_path, "r") as file:
            if chosen_file_path.split(".")[-1] == "py":
                parsed_data = concat(parsed_data, parse_py_file(file))
            elif chosen_file_path.split(".")[-1] == "java":
                parsed_data = concat(parsed_data, parse_java_file(file))

    if parsed_data:
        print("Число дефектів в програмі: ", calculate_error(parsed_data))


if __name__ == "__main__":
    main()
