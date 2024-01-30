const mp = new MercadoPago('TEST-4be24b6e-b154-4432-9747-3e610bfb757c');


const payMercadoPago = async () => {
    try {
        const orderData = {
            title: "plan",
            quanty: 1,
            price: 20000
        };

    await PageMethods.GetCiudades(orderData,onSuccess, onError);
    } catch (error)
    {
        alert("error")
    }

}

function onSucces(pagePreference) {
    console.log(pagePreference)
    createCheckoutButton(pagePreference.id)
}
function createCheckoutButton(id) {
    const bricksBuilder = mp.bricks();

    const renderComponent = async () => {
        if (windows.checkoutButton) window.checkoutButton.unmount();

        await bricksBuilder.create("wallet", "wallet_container", {
            initialization: {
                preferenceId: id,
            },
        });

    }

    renderComponent();
}








