*Key Features*

Vehicle Classes:

- Car: Inherits from the Vehicle class, includes a safety rating.
- Motorcycle: Inherits from the Vehicle class, includes rider age.
- CargoVan: Inherits from the Vehicle class, includes years of driving experience.

Invoice Generation:

- Calculates rental costs and insurance based on vehicle type, rental period, and additional attributes (e.g., safety rating, rider age).
- Applies discounts or additional charges based on specific conditions.

User Interaction:

- Users select a vehicle type, choose from available vehicles, and enter rental details.
- The system validates user input and ensures correct date formats and rental periods.

*Approach to the Solution*

- Inheritance and Polymorphism: Utilized inheritance to create a base Vehicle class and derived classes (Car, Motorcycle, CargoVan) to represent specific vehicle types with additional properties.
- Invoice Calculation: Implemented logic to calculate rental costs and insurance, incorporating conditional adjustments for discounts and additional charges.
- User-Friendly Console Interface: Developed methods to handle user input, validate data, and provide clear instructions, ensuring a smooth user experience.

*Usage*

Run the Program:
- Execute the console application.

Follow Prompts:

- Select a vehicle type (car, motorcycle, cargo van).
- Choose a specific vehicle from the list.
- Enter rental details (name, rental dates, etc.).

View Invoice:

- The program will calculate and display the invoice with rental and insurance costs.
