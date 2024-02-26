-- Creating Users table
CREATE TABLE Users (
    id SERIAL PRIMARY KEY,
    name VARCHAR(255),
    email VARCHAR(255) UNIQUE,
    password VARCHAR(255),
    role VARCHAR(50)
);

-- Creating Hotels table
CREATE TABLE Hotels (
    id SERIAL PRIMARY KEY,
    name VARCHAR(255),
    address TEXT,
    city VARCHAR(100),
    status BOOLEAN,
    rating INT,
    description TEXT
);

-- Creating Rooms table
CREATE TABLE Rooms (
    id SERIAL PRIMARY KEY,
    hotel_id INT,
    number VARCHAR(50),
    base_cost DECIMAL(10, 2),
    taxes DECIMAL(10, 2),
    type VARCHAR(50),
    status BOOLEAN,
    location VARCHAR(255),
    FOREIGN KEY (hotel_id) REFERENCES Hotels(id)
);

-- Creating Reservations table
CREATE TABLE Reservations (
    id SERIAL PRIMARY KEY,
    room_id INT,
    user_id INT,
    check_in_date DATE,
    check_out_date DATE,
    number_of_guests INT,
    status VARCHAR(50),
    total_cost DECIMAL(10, 2),
    FOREIGN KEY (room_id) REFERENCES Rooms(id),
    FOREIGN KEY (user_id) REFERENCES Users(id)
);

-- Creating Guests table
CREATE TABLE Guests (
    id SERIAL PRIMARY KEY,
    reservation_id INT,
    first_name VARCHAR(255),
    last_name VARCHAR(255),
    date_of_birth DATE,
    gender VARCHAR(50),
    document_type VARCHAR(50),
    document_number VARCHAR(100),
    email VARCHAR(255),
    contact_phone VARCHAR(100),
    FOREIGN KEY (reservation_id) REFERENCES Reservations(id)
);

-- Creating EmergencyContacts table
CREATE TABLE EmergencyContacts (
    id SERIAL PRIMARY KEY,
    reservation_id INT,
    full_name VARCHAR(255),
    contact_phone VARCHAR(100),
    FOREIGN KEY (reservation_id) REFERENCES Reservations(id)
);
