## How you organized the application 
Created a Blazor Webapp application with the structure:

Components - This holds my Frontend and Backend code for the 3 pages
Data - This has my DBContext for my SQLite DB
Migrations - Used migrations create tables, contstraints and initial seeding of data(added a backup in the code if cannot seed from DB)
Models - All object creation

## Where you enforced validation and rules, and why 
I tried to ensure validation in all files especially around saving DB changes
Added rules to ensure unique identifiers are correctly enforced example email and isbn

## One trade-off you made due to the timebox 
Traded off on perfecting the CRUD on Lenders and Books to ensure Loans followed all rules and excutes correctly
