let checkBoxes = Array.from(document.querySelectorAll('.ingredients'))

let downloadBtn = document.querySelector('#download-btn')
let saveBtn = document.querySelector('#save-btn')

checkBoxes.forEach(cb => cb.addEventListener('change', checkButtonStatus))

function checkButtonStatus() {
    let checkedCount = checkBoxes.filter(cb => cb.checked)

    if (checkedCount.length == 0) {
        downloadBtn.disabled = true
        saveBtn.disabled = true
    } else {
        downloadBtn.disabled = false
        saveBtn.disabled = false
    }
}

function CheckAllIngredients() {
    let checkedCount = checkBoxes.filter(cb => cb.checked)

    if (checkedCount < checkBoxes.length) {
        for (var i = 0; i < checkBoxes.length; i++) {
            checkBoxes[i].checked = true
        }
    } else {
        for (var i = 0; i < checkBoxes.length; i++) {
            checkBoxes[i].checked = false
        }
    }

    checkButtonStatus()
}

checkButtonStatus()