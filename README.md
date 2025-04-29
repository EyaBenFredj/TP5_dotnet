
# 🍽️ RestoManager - TP5 ASP.NET Core MVC

A restaurant management web app built with **ASP.NET Core MVC**, using **Code First + Fluent API** and styled with **Bootstrap (Flatly Blue Theme)**.

> 🧪 Developed as part of **TP5** — ENISo IA2 ASP.NET Core MVC course  
> 👨‍🏫 Professors: Naoufel KHAYATI, Imen KHADHRAOUI, Hamza GBADA

---

## 📁 Project Structure

```
TP5/
├── Controllers/
│   ├── AvisController.cs
│   ├── ProprietairesController.cs
│   └── RestaurantsController.cs
│
├── Models/
│   └── RestosModel/
│       ├── Avis.cs
│       ├── Proprietaire.cs
│       ├── Restaurant.cs
│       ├── RestosDbContext.cs
│       └── RestosDbContextFactory.cs
│
├── Migrations/
│   └── [Entity Framework Migration Files]
│
├── Views/
│   ├── Avis/
│   │   ├── AvisParRestaurant.cshtml
│   │   ├── Create.cshtml
│   │   ├── Delete.cshtml
│   │   ├── Details.cshtml
│   │   ├── Edit.cshtml
│   │   └── Index.cshtml
│   │
│   ├── Proprietaires/
│   │   ├── Create.cshtml
│   │   ├── Delete.cshtml
│   │   ├── Details.cshtml
│   │   ├── Edit.cshtml
│   │   └── Index.cshtml
│   │
│   ├── Restaurants/
│   │   ├── Create.cshtml
│   │   ├── Delete.cshtml
│   │   ├── Details.cshtml
│   │   ├── Edit.cshtml
│   │   ├── Index.cshtml
│   │   ├── TopRated.cshtml
│   │   └── DetailsWithAvis.cshtml
│   │
│   └── Shared/
│       ├── _Layout.cshtml
│       └── _ValidationScriptsPartial.cshtml
│
├── wwwroot/
├── appsettings.json
├── Program.cs
└── .gitignore
```

---

## 🌐 Features

✅ Code First with Fluent API  
✅ Data modeling with 3 entities:
- `Proprietaire` → owns one or more `Restaurant`s  
- `Restaurant` → receives multiple `Avis` (reviews)

✅ Entity relationships configured manually (no conventions)  
✅ LINQ join queries:
- View all Avis for a restaurant
- Filter Avis by restaurant (by ID)
- List restaurants with average note ≥ 3.5

✅ Full CRUD operations for all entities  
✅ Styled UI with Bootstrap 5 (Flatly theme)  
✅ Dropdowns for foreign key selection (e.g. Restaurant → Proprietaire)

---

## 🛠️ Technologies Used

| Tech                  | Description                           |
|-----------------------|---------------------------------------|
| ASP.NET Core MVC      | Web application framework             |
| Entity Framework Core | Code First + Fluent API + Migrations |
| SQL Server LocalDB    | Database engine                       |
| Bootstrap 5 (Flatly)  | UI styling and layout                 |
| LINQ                  | Querying relational data              |

---

## 🚀 How to Run the App Locally

1. **Clone the repository**

```bash
git clone https://github.com/YOUR_USERNAME/RestoManager_TP5.git
cd RestoManager_TP5
```

2. **Open the solution in Visual Studio**

3. **Apply EF Core migrations**

```bash
# In NuGet Package Manager Console:
Update-Database
```

4. **Run the app**

```bash
Ctrl + F5  # Start without debugging
```

📌 The app will start on:  
`https://localhost:PORT/Proprietaires` (default controller)

---

## 📸 Screenshots (Optional)

Add screenshots of these pages:

- ✅ Restaurant Index View (styled)
- ✅ Proprietaire CRUD pages
- ✅ TopRated view (average note ≥ 3.5)
- ✅ DetailsWithAvis / AvisParRestaurant

You can add them like:

```markdown
### 🖼️ Restaurant List Page

![Restaurant Index](screenshots/restaurant-index.png)
```

---

