# 🏨 Hotel Booking System

A full-stack hotel booking application inspired by Booking.com, built with:

- 🔧 **Backend**: ASP.NET Core Web API + Entity Framework Core
- 🌐 **Frontend**: Vue.js 3 + Composition API
- 🗃️ **Database**: SQL Server

Live repo: [https://github.com/Deepali-create-creator/hotel-booking-system](https://github.com/Deepali-create-creator/hotel-booking-system)

---

## 📁 Project Structure

hotel-booking-system/
│
├── HotelBookingApp/ # Backend - ASP.NET Core
│ ├── Controllers/
│ ├── Entities/
│ ├── DTOs/
│ ├── Repository/
│ ├── AppDbContext.cs
│ └── ...
│
├── Hotel-booking-frontend/ # Frontend - Vue.js
│ ├── src/
│ ├── public/
│ ├── package.json
│ └── ...




---

## ⚙️ Prerequisites

Make sure the following are installed:

- [.NET SDK 7.0+](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Node.js v16+](https://nodejs.org/)
- npm (comes with Node.js)

---

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/Deepali-create-creator/hotel-booking-system.git
cd hotel-booking-system

=>Backend Setup (ASP.NET Core)

cd HotelBookingApp

Update appsettings.json Connection String

"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=HotelBookingDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
🛠️ Run Database Migrations

dotnet ef database update
▶️ Start the Backend

dotnet run
Backend will run at https://localhost:7237


Frontend Setup (Vue.js)

cd ../Hotel-booking-frontend
📦 Install Dependencies

npm install
▶️ Start the Frontend Dev Server

npm run dev
Frontend runs at: http://localhost:5173

Authentication Features
✅ Register and Login

🔐 Only logged-in users can book rooms (Not built at the moment will work on this)



Key Features
🔍 Search hotels by location or hotel name

📍 Dropdown list of dynamic locations

🏨 Hotel listings with room availability

✅ Booking functionality (requires login)(at the moment if room is available it will be booked)


 API Overview

| Method | Endpoint               | Description                    |
| ------ | ---------------------- | ------------------------------ |
| GET    | `/api/Hotel/search`    | Search hotels                  |
| GET    | `/api/Hotel/locations` | Get distinct hotel locations   |
| POST   | `/api/Auth/register`   | Register a new user            |
| POST   | `/api/Auth/login`      | Login    |
| POST   | `/api/Booking/book`    | Book a room |

