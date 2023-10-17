def process_commit_message(author_name, commit_message):
    words = commit_message.split(" ")[:5]
    print(words)
    combinations = [words[i:i+3] for i in range(3)]
    return ['wewe']+[" ".join(combination) for combination in combinations]

print(process_commit_message("nikolay", "asssss l43 sssssss www  eeeeeeeee eenjz "))