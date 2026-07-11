# W01 Assignment Notes

## Part 1: Pizza API Evidence

The Pizza API contains the original records and one additional record.

### GET Response — 200 OK

```json
[
  {
    "id": 1,
    "name": "Classic Italian",
    "isGlutenFree": false
  },
  {
    "id": 2,
    "name": "Veggie",
    "isGlutenFree": true
  },
  {
    "id": 3,
    "name": "BBQ Chicken",
    "isGlutenFree": false
  }
]
```

The additional record is:

```json
{
  "id": 3,
  "name": "BBQ Chicken",
  "isGlutenFree": false
}
```

### API Test Status Codes

- GET: 200 OK
- POST: 201 Created
- PUT: 204 No Content
- DELETE: 204 No Content

## Part 2: Sales Summary Function

```csharp
void GenerateSalesSummary(
    IEnumerable<string> salesFiles,
    string outputFile
)
{
    double grandTotal = 0;
    StringBuilder details = new StringBuilder();

    foreach (var file in salesFiles)
    {
        string salesJson = File.ReadAllText(file);

        SalesData? data =
            JsonConvert.DeserializeObject<SalesData?>(salesJson);

        double fileTotal = data?.Total ?? 0;
        grandTotal += fileTotal;

        string relativePath =
            Path.GetRelativePath(currentDirectory, file);

        details.AppendLine($"  {relativePath}: {fileTotal:C}");
    }

    StringBuilder report = new StringBuilder();

    report.AppendLine("Sales Summary");
    report.AppendLine("----------------------------");
    report.AppendLine($"Total Sales: {grandTotal:C}");
    report.AppendLine();
    report.AppendLine("Details:");
    report.Append(details);

    File.WriteAllText(outputFile, report.ToString());

    Console.WriteLine(report.ToString());
    Console.WriteLine($"Report saved to: {outputFile}");
}
```

### Generated Report

```text
Sales Summary
----------------------------
Total Sales: HK$2,012.20

Details:
  stores\sales.json: HK$88.88
  stores\201\sales.json: HK$501.22
  stores\202\sales.json: HK$1,234.22
  stores\203\sales.json: HK$99.00
  stores\204\sales.json: HK$88.88
```