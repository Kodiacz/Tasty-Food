var ingredientsIndex = 0
var stepsIndex = 0

function createSuffix(lastDigit) {
    let suffix;

    switch (lastDigit) {
        case 1: suffix = "st"; break;
        case 2: suffix = "nd"; break;
        case 3: suffix = "rd"; break;
        default: suffix = "th"; break;
    }

    return suffix;
}

function addMoreIngredientFields() {
    let lastDigit = stepsIndex % 10
    let suffix = createSuffix(lastDigit);
    let validationPTagProduct = `validation-p-tag-product-${ingredientsIndex}`
    let validationPTagQuantity = `validation-p-tag-quantity-${ingredientsIndex}`

    $("#IngridientsDiv").append(`
            <p id="${validationPTagProduct}" class="text-danger"></p>
            <p id="${validationPTagQuantity}" class="text-danger"></p>
            <p id="ingredient-paragraph-${ingredientsIndex}" class="ingredients-paragraphs">${ingredientsIndex + 1}${suffix} Ingredient:</p>
            <div class='input-group ingredients-divs' id="ingredient-div-${ingredientsIndex}">
            <span class="input-group-text">Product and Quantity</span>
            <input class="form-control input-products" name="Ingredients[${ingredientsIndex}].Product" type="text" placeholder='e.g. potato'/>
            <input class="form-control input-quantities" name='Ingredients[${ingredientsIndex}].Quantity' type="text" placeholder='e.g. 1.3 kg'/>
            <button type="button" onclick="removeIngredient('${ingredientsIndex}')" class="btn btn-outline-danger form-control delete-ingredients-btns"><i class="bi bi-trash3"></i></button>
            </span>
            </div>
                    `)

    $(`input[name="Ingredients[${ingredientsIndex}].Product"]`).on('change', (e) => validate(e, validationPTagProduct, 'product'))
    $(`input[name="Ingredients[${ingredientsIndex}].Quantity"]`).on('change', (e) => validate(e, validationPTagQuantity, 'quantity'))

    ingredientsIndex++
}

function addMoreDirectionsFields() {
    let lastDigit = stepsIndex % 10
    let suffix = createSuffix(lastDigit)
    let validationPTag = `validation-p-tag-steps-${stepsIndex}`

    $('#DirectionsDiv').append(`
            <div class="steps-divs" id="step-div-${stepsIndex}">
            <div class="d-grid gap-2 d-md-flex justify-content-between mt-3">
            <p id="${validationPTag}" class="text-danger"></p>
            <p class="steps-paragraphs">${stepsIndex + 1}${suffix} Step:</p>
            <span class="d-inline-block" tabindex="0" data-bs-toggle="popover" data-bs-placement="left" data-bs-trigger="hover focus" data-bs-content="Delete this step">
            <button type="button" onclick="removeStep('${stepsIndex}')" class="btn btn-outline-danger form-control delete-steps-btns"><i class="bi bi-trash3"></i></button>
            </span>
            </div>
            <textarea class='form-control input-steps' name='Directions[${stepsIndex}].Step' aria-required='true' rows='5'></textarea>
            <span class="text-danger field-validation-valid" data-valmsg-for="Directions[${stepsIndex}].Step" data-valmsg-replace="true"></span>
            </div>
                    `);

    $(`textarea[name="Directions[${stepsIndex}].Step"]`).on('change', (e) => validate(e, validationPTag, 'step'))

    stepsIndex++
}

function removeIngredient(id) {

    let divToRemove = document.querySelector(`#ingredient-div-${id}`)
    let paragraphToRemove = document.querySelector(`#ingredient-paragraph-${id}`)

    paragraphToRemove.remove()
    divToRemove.remove()

    let allIngredientsParagraphs = document.querySelectorAll(`.ingredients-paragraphs`)
    let allIngredientsDivs = document.querySelectorAll(`.ingredients-divs`)
    let allProducts = document.querySelectorAll('.input-products')
    let allQuantities = document.querySelectorAll('.input-quantities')
    let allDeleteIngredientBtns = document.querySelectorAll('.delete-ingredients-btns')

    for (let i = 0; i < allProducts.length; i++) {
        let lastDigit = (i + 1) % 10
        let suffix = createSuffix(lastDigit);

        allIngredientsParagraphs[i].innerText = `${i + 1}${suffix} Ingredient:`
        allIngredientsParagraphs[i].setAttribute('id', `ingredient-paragraph-${i}`)
        allIngredientsDivs[i].setAttribute('id', `ingredient-div-${i}`)
        allProducts[i].setAttribute('name', `Ingredients[${i}].Product`)
        allQuantities[i].setAttribute('name', `Ingredients[${i}].Quantity`)
        allDeleteIngredientBtns[i].setAttribute('onclick', `removeIngredient(${i})`)
    }

    ingredientsIndex = document.querySelectorAll('.input-products').length
}

function removeStep(id) {
    let divToRemove = document.querySelector(`#step-div-${id}`)

    divToRemove.remove()

    let allDirectionsParagraphs = document.querySelectorAll(`.steps-paragraphs`)
    let allDirectionsDivs = document.querySelectorAll(`.steps-divs`)
    let allSteps = document.querySelectorAll('.input-steps')
    let allDeleteDirectionsBtns = document.querySelectorAll('.delete-steps-btns')

    for (let i = 0; i < allSteps.length; i++) {
        let lastDigit = (i + 1) % 10
        let suffix = createSuffix(lastDigit);

        allDirectionsParagraphs[i].innerText = `${i + 1}${suffix} Step:`
        allDirectionsDivs[i].setAttribute('id', `step-div-${i}`)
        allSteps[i].setAttribute('name', `Directions[${i}].Step`)
        allDeleteDirectionsBtns[i].setAttribute('onclick', `removeStep(${i})`)
    }

    stepsIndex = document.querySelectorAll('.input-steps').length
}

function getAllProductInputFields() {
    return document.querySelectorAll('.input-products')
}

function getAllQuantityInputFields() {
    return document.querySelectorAll('.input-quantities')
}

function getAllStepInputFields() {
    return document.querySelectorAll('.input-steps')
}