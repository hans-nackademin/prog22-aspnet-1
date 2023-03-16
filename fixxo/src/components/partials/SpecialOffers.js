import React from 'react'
import OfficeStyleImage from '../../assets/images/office-style.png'
import PartyStyleImage from '../../assets/images/party-style.png'

const SpecialOffers = () => {
  return (
    <div className="offer-grid container-fluid">
        <img id="office-style" src={OfficeStyleImage} alt="" />

        <div className="offer">
            <div className="red-border">
                <div className="content">
                    <h1>50% Offer</h1>
                    <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Facilis, ipsam quo voluptatum facere iure fuga. Necessitatibus quasi voluptatem delectus nam?</p>
                    <button className="btn-white">FLASH SALE</button>
                </div>
            </div>
        </div>
        <img id="party-style" src={PartyStyleImage} alt="" />
    </div>
  )
}

export default SpecialOffers