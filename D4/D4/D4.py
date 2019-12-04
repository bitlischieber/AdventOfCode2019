import re

# Your puzzle input is 246540-787419.

## Part 1
pwords = []
for i in range(246540,787419):
    if(int(str(i)[0]) <= int(str(i)[1]) <= int(str(i)[2]) <= int(str(i)[3]) <= int(str(i)[4]) <= int(str(i)[5])):
        if((str(i)[0] == str(i)[1]) or (str(i)[1] == str(i)[2]) or (str(i)[2] == str(i)[3]) or (str(i)[3] == str(i)[4]) or (str(i)[4] == str(i)[5])):
            pwords.append(i)
            print("Candidate found " + str(i))
print("Number of possible passwords: " + str(len(pwords)))
input()

## Part 2

pwords2 = []
for pw in pwords:
    # search for packages of three and more digits
    x = re.sub(r"(\d)\1{2,6}", "", str(pw))
    if(x):
        # but allow packages with two other digits
        y = re.search(r"(\d)\1", str(x))
        if(not y):
            print("Invalid password " + str(pw))
        else:
            # collect valid pw for counting
            pwords2.append(pw)

print("Number of possible passwords left: " + str(len(pwords2)))
input()