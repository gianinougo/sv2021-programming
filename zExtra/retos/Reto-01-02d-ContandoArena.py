# Reto 1.02 - Contando en la arena (acepta 369)
# Contar en base 1
# 
# Ejemplo de entrada
# 1
# 4
# 6
# 0
# 
# Salida para esa entrada
# 1
# 1111
# 111111
# 
# Solución en Python 2 (variantes más natural en Python)

n = int(input())
while n != 0:
    print("1" * n)
    n = int(input())
