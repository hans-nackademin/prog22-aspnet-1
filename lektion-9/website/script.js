const handleRegister = async (e) => {
    e.preventDefault()

    const user = {
        firstName: e.target[0].value,
        lastName: e.target[1].value,
        email: e.target[2].value,
        password: e.target[3].value,
        streetName: e.target[4].value,
        postalCode: e.target[5].value,
        city: e.target[6].value
    }

    const result = await fetch('https://localhost:7034/api/Authentication/SignUp', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    })

    if (result.status === 201)
        window.location.replace("login.html")

}

const handleLogin = async (e) => {
    e.preventDefault()

    const user = {
        email: e.target[0].value,
        password: e.target[1].value
    }

    const result = await fetch('https://localhost:7034/api/Authentication/SignIn', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    })

    if (result.status === 200) {
        const accessToken = await result.text()
        localStorage.setItem("accessToken", accessToken)
        window.location.replace("products.html")
    }
}

const getProducts = async () => {
    const result = await fetch('https://localhost:7034/api/products', {
        method: 'get',
        headers: {
            'Authorization': `bearer ${localStorage.getItem("accessToken")}`
        }
    })

    const data = await result.json()
    console.log(data)
}