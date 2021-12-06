# Reto 2.02: Palabras pentavocálicas (Acepta el reto 300)
# 
# Entrada de ejemplo
# 4
# albaricoque
# seculariza
# peliagudo
# abracadabra
# 
# Salida de ejemplo
# SI
# NO
# SI
# NO


def esPanvocalica(palabra):
    
    esPanVocal = False

    if "a" in palabra and "e" in palabra and \
            "i" in palabra and "o" in palabra and \
            "u" in palabra:
        esPanVocal = True;        

    return esPanVocal;


# Cuerpo del programa

casos = int(input())
      
for i in range(1, casos+1):
    
    palabra = input()
    if esPanvocalica(palabra):
        print("SI")
    else:
        print("NO")
