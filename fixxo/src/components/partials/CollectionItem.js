import React from 'react'
import { NavLink } from 'react-router-dom'
import StarRating from './StarRating'

const CollectionItem = () => {
  return (
    <div className="item">
        <div className="image-section">
            <img src="https://kyhnet22sa.blob.core.windows.net/product-images/black-coat.png" alt="" />
            <div className="menu">
              <div className="icons">
                  <button className="link"><i className="fa-regular fa-code-compare"></i></button>
                  <button className="link"><i className="fa-regular fa-heart"></i></button>
                  <button className="link"><i className="fa-regular fa-bag-shopping"></i></button>
              </div>
              <NavLink className="btn-theme" to="/products">QUICK VIEW</NavLink>
            </div>
        </div>
        <div className="body-section">
            <div className="category">Coats</div>
            <div className="name">Black Coat of the Best Brandc</div>
            <StarRating rating="3" />
            <div className="price">$3500</div>
        </div>
    </div>
  )
}

export default CollectionItem