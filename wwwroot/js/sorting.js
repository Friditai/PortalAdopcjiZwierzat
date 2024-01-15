document.addEventListener('DOMContentLoaded', function () {
    const table = document.getElementById('animalTable');
    const selectColumn = document.getElementById('sortCategory');
    const sortDirectionAsc = document.getElementById('asc');
    const sortDirectionDesc = document.getElementById('desc');

    console.log("Klik");

    selectColumn.addEventListener('change', updateTable);
    sortDirectionAsc.addEventListener('change', updateTable);
    sortDirectionDesc.addEventListener('change', updateTable);

    function updateTable() {
        const column = selectColumn.value;
        const order = sortDirectionAsc.checked ? 'asc' : 'desc';

        sortTable(table, column, order);
    }

    function sortTable(table, column, order) {
        const tbody = table.querySelector('tbody');
        const rows = Array.from(tbody.querySelectorAll('tr'));

        rows.sort((a, b) => {
            const aValue = a.querySelector(`td[data-column="${column}"]`).textContent;
            const bValue = b.querySelector(`td[data-column="${column}"]`).textContent;

            if (order === 'asc') {
                return aValue.localeCompare(bValue);
            } else {
                return bValue.localeCompare(aValue);
            }
        });

        tbody.innerHTML = '';

        rows.forEach(row => {
            tbody.appendChild(row);
        });
    }
});