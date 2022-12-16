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