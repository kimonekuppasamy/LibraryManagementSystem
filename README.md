# LibraryManagementSystem

## Created a simple CRUD Library Management System Application
### Features Implemented
1. Books Management
Add, edit, and delete books.

Validation: ISBN must be unique.

Uses RadzenDataGrid with filtering, sorting, and paging.

2. Lenders Management
Add, edit, and delete lenders.

Uses RadzenDataGrid with filtering, sorting, and paging.

3. Loans Management
Create, view, and return loans.

#### Business rules enforced:

* Cannot loan a book if CopiesAvailable == 0.
* Prevent duplicate active loans per lender/book.
* A lender cannot have more than 5 active loans simultaneously.
* Overdue books block loans for new books.
* Default loan period: 14 days.
* On loan: decrements CopiesAvailable.
* On return: sets ReturnDate and increments CopiesAvailable.
* Loans are displayed with active vs returned status, and overdue loans highlighted.

Uses RadzenDataGrid for display with sorting, filtering, and paging.

4. Data Seeding
Books, lenders, and sample loans are seeded automatically at project startup.
Ensures the app is ready to use without manual data entry.


## Misses
- Testing each rule properly
- Adding more exception handling
- First time using Radzen, so some features may be missing or not fully utilized.
- Code cleanup from the template when project was created
