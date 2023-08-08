id=0
id_set=set()

while True:
    id=id+1
    id_set.add(id)
    if id%100==0:
        print(len(id_set))