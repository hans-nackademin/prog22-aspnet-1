import React from 'react'

const StarRating = ({rating}) => {
    const stars = Array.from({length: 5}, (_, index) => (
        <i key={index} className={`fa-sharp fa-star ${index < rating ? "fa-solid" : "fa-regular"}`}></i>
    ))
  
    return (
    <div className="star-rating">{stars}</div>
  )
}

export default StarRating