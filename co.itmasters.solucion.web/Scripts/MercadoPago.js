const mp = new MercadoPago('APP_USR-d97cfe7f-43dd-4dd6-8966-90082c8bd905');


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








