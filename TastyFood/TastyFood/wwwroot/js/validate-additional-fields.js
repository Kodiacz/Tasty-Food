function validate(e, id, type) {
    let inputValue = e.target.value
    let validationPTag = document.querySelector(`#${id}`)
    let statementCase = type == 'step' ? 450 : 70

    if (inputValue.length > statementCase || inputValue.length == 0) {
        e.target.classList.add("is-invalid")
        validationPTag.textContent = `The ${type} must be less then ${statementCase} and more then 0 symbols`
    } else {
        e.target.classList.remove("is-invalid")
        e.target.classList.add("is-valid")
        validationPTag.textContent = ""
    }

    console.log(inputValue)
}