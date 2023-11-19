export function formatDate(inputDate) {
    const dateParts = inputDate.split('-');

    const formattedDate = `${dateParts[2]}/${dateParts[1]}/${dateParts[0]}`;

    return formattedDate;
}