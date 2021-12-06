# Reto 2.01: Máquina de cálculo
# 
# Ejemplo de entrada
# 5
# 5 + -13
# 10 / 2
# 7 * 3
# 3 / 0
# 5 - 13
# 
# Ejemplo de salida
# -8
# 5
# 21
# ERROR
# -8 
        
casos = int(input())
      
for i in range(1, casos+1):
    
    txtOriginal = input()
    argumentos = txtOriginal.split()
    
    num1 = int(argumentos[0])
    num2 = int(argumentos[2])
    operador = argumentos[1]

    if operador == '+':
        print(num1 + num2)
    elif operador == '-':
        print(num1 - num2)
    elif operador ==  '*':
        print(num1 * num2);
    elif operador ==  '/':
        if num2 != 0:
            print(num1 / num2);
        else:
            print("ERROR");
