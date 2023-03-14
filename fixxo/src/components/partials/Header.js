import React from 'react'
import { Link, NavLink } from 'react-router-dom'

const Header = () => {
  return (
    <header>
        <div className="container">
            <Link id="logotype" to="/">Fixxo.</Link>
            
            <div id="menu">
                <nav className="menu-links links">
                    <NavLink className="link" to="/">Home</NavLink>
                    <NavLink className="link" to="/products">Products</NavLink>
                    <NavLink className="link" to="/contacts">Contacts</NavLink>
                </nav>

                <nav className="menu-icons icons">
                    <NavLink className="link" to="/search"><i className="fa-regular fa-search"></i></NavLink>
                    <NavLink className="link" to="/compare"><i className="fa-regular fa-code-compare"></i></NavLink>
                    <NavLink className="link" to="/favorites"><i className="fa-regular fa-heart"></i></NavLink>
                    <NavLink className="link" to="/cart"><i className="fa-regular fa-bag-shopping"></i></NavLink>
                    <NavLink className="link ms-5" to="/account"><i className="fa-regular fa-user"></i></NavLink>
                </nav>
            </div>

            <div id="toggle-icon" className="icons">
                <button className="link"><i className="fa-regular fa-bars"></i></button>
            </div>
        </div>
    </header>
  )
}

export default Header