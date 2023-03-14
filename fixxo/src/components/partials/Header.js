import React from 'react'
import { Link, NavLink } from 'react-router-dom'

const Header = () => {
  return (
    <header>
        <div className="container">
            <Link to="/">Fixxo.</Link>
            
            <nav>
                <NavLink to="/">Home</NavLink>
                <NavLink to="/products">Products</NavLink>
                <NavLink to="/contacts">Contacts</NavLink>
            </nav>

            <nav>
                <NavLink><i className="fa-regular fa-search"></i></NavLink>
                <NavLink><i className="fa-regular fa-code-compare"></i></NavLink>
                <NavLink><i className="fa-regular fa-heart"></i></NavLink>
                <NavLink><i className="fa-regular fa-bag-shopping"></i></NavLink>
                <NavLink><i className="fa-regular fa-user"></i></NavLink>
            </nav>

            <div>
                <button><i className="fa-regular fa-bars"></i></button>
            </div>

        </div>
    </header>
  )
}

export default Header