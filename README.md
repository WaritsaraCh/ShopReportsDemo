# Demo (Windows Forms + Crystal Reports + Entity Framework)

## Purpose
- Demo is a small Windows Forms application that shows how to generate Crystal Reports from an Entity Framework model. The app reads data from a `dbshopReal` SQL Server database (products, customers, purchases) and displays several report types (simple list, grouped/summed, joins and filtered reports).

## Key Features
- Simple product listing report
- Group + sum report (aggregate by product type)
- Joined reports combining customers, purchases and products
- Parameterized reports: filter by customer id or product type id

## Project Structure (important files)
- `Form1.cs` / `Form1.Designer.cs` — main UI with buttons and a `CrystalReportViewer`.
- `Model1.edmx`, `Model1.Designer.cs`, `Model1.Context.cs` — Entity Framework EDMX model and generated context.
- Entity classes: `tb_product.cs`, `tb_customer.cs`, `tb_buy.cs`, `ProductType.cs`.
- Crystal reports: `CrystalReport1.rpt`, `CrystalReportGroup.rpt`, `CrystalReportJoin.rpt`, `CrystalReportJoinTypeID.rpt` (embedded resources and generated `.cs` wrappers).
- `App.config` — EF connection strings and runtime settings.
- `Demo.sln` / `Demo.csproj` — Visual Studio solution and project (targets .NET Framework 4.7.2).

## Requirements
- Windows (Crystal Reports runtime is Windows-only)
- Visual Studio (2017, 2019 or 2022) with .NET Desktop workload
- .NET Framework 4.7.2 (project target)
- SAP Crystal Reports runtime + developer components for Visual Studio (assemblies referenced in the project: `CrystalDecisions.*` v13.x)
- SQL Server with a database named (or compatible with) `dbshopReal` matching the EDMX schema

## Dependencies
- Entity Framework 6.2.0 (NuGet package referenced via `packages.config`)
- CrystalDecisions assemblies (provided by Crystal Reports runtime)

## Build & Run
1. Open `Demo.sln` in Visual Studio.
2. Restore NuGet packages (Visual Studio should restore packages using `packages.config`).
3. Ensure Crystal Reports developer runtime is installed on your machine (so referenced CrystalDecisions assemblies are available).
4. Optionally update the connection string in `App.config` to point to your SQL Server instance and database (see the next section).
5. Build the solution (`Build > Build Solution`).
6. Run the project (F5). The main form shows buttons: `SimpleReport`, `Group and Sum`, `Join`, and `TypeID`.

## How the UI works
- `SimpleReport` (button1): loads all products and displays `CrystalReport1`.
- `Group and Sum` (button2): loads product data and displays `CrystalReportGroup` with grouping/aggregation.
- `Join` (button3): expects a customer id in `textBox1`. It loads customers, products, buys and product types and sets the `cusid` parameter on `CrystalReportJoin`.
- `TypeID` (button4): expects a product type id in `textBox2`. It loads products and product types and sets the `typeid` parameter on `CrystalReportJoinTypeID`.

## Database / Connection string
- The project embeds two Entity connection strings in `App.config`:
  - `dbshopRealEntities` (points to `K0NG\SQLEXPRESS` in the checked-in config)
  - `dbshopRealEntities1` (points to `VARITSARA` in the checked-in config)
- Update the provider connection string inside the `connectionStrings` section of `App.config` if you need to point to your SQL Server instance or use SQL authentication.

Example provider connection substring to change:
```
provider connection string="data source=YOUR_SERVER;initial catalog=dbshopReal;integrated security=True;..."
```

## Crystal Reports notes
- The `.rpt` files are embedded resources and the project references the generated report wrappers (e.g. `CrystalReport1.cs`).
- If you see missing assembly errors at runtime, install the SAP Crystal Reports runtime for the matching 13.x version used by this project.

## Troubleshooting
- "Could not load file or assembly CrystalDecisions...": Install the Crystal Reports runtime.
- EF connection errors: verify the `App.config` connection string and that SQL Server allows connections.
- If images or binary fields do not display correctly, verify the report field types and that `pro_image` is stored as expected.

## Next steps / Suggestions
- If you want to decouple reports from the embedded dataset, consider creating a lightweight DTO layer or exporting report datasets to `.xsd` files used by the reports.
- Migrate from EDmx to Code-First (optional) if you prefer code-based EF models.

## License
- No license specified. Modify this README to add license/attribution as needed.

---
If you want, I can also:
- run a quick scan for TODOs or missing references;
- update the `App.config` to point to a local SQL Server instance you provide;
- add a short CONTRIBUTING section or sample data SQL script.
