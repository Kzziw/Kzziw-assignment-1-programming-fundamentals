"""Assignment 1: Review of programming fundamentals."""
import math


def read_number(prompt):
    while True:
        try:
            number = float(input(prompt))
            if math.isfinite(number):
                return number
        except ValueError:
            pass
        print("Enter a valid number.")


def calculator():
    a = read_number("Enter the first number: ")
    b = read_number("Enter the second number: ")
    operation = input("Enter operation (+, -, *, /): ").strip()

    if operation == "+":
        result = a + b
    elif operation == "-":
        result = a - b
    elif operation == "*":
        result = a * b
    elif operation == "/":
        if b == 0:
            print("Error: Division by zero.")
            return
        result = a / b
    else:
        print("Invalid operation.")
        return

    print(f"Result: {result:g}")


def temperature_converter():
    direction = input("Enter C or F: ").strip().upper()
    if direction == "C":
        celsius = read_number("Enter temperature: ")
        fahrenheit = celsius * 1.8 + 32
        print(f"{celsius:g}°C = {fahrenheit:g}°F")
    elif direction == "F":
        fahrenheit = read_number("Enter temperature: ")
        celsius = (fahrenheit - 32) / 1.8
        print(f"{fahrenheit:g}°F = {celsius:g}°C")
    else:
        print("Invalid conversion direction.")


def grade_average():
    try:
        count = int(input("Enter the number of grades: "))
    except ValueError:
        print("Invalid number of grades.")
        return
    if count <= 0:
        print("Invalid number of grades.")
        return

    total = 0
    for i in range(count):
        grade = read_number(f"Enter grade {i + 1}: ")
        while grade < 1 or grade > 6:
            grade = read_number("Enter a grade between 1 and 6: ")
        total += grade

    average = total / count
    print(f"Average: {average:.2f}")
    if average >= 3.0:
        print("The student passed.")
    else:
        print("The student failed.")


def main():
    while True:
        print("\n===== ASSIGNMENT 1 =====")
        print("1. Calculator")
        print("2. Temperature converter")
        print("3. Student grade average")
        print("0. Exit")
        choice = input("Select a task: ").strip()

        if choice == "1":
            calculator()
        elif choice == "2":
            temperature_converter()
        elif choice == "3":
            grade_average()
        elif choice == "0":
            print("Goodbye!")
            break
        else:
            print("Invalid choice.")


if __name__ == "__main__":
    main()
