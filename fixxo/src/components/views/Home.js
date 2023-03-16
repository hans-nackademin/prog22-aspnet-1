import React from 'react'
import Collection from '../partials/Collection'
import Header from '../partials/Header'
import Showcase from '../partials/Showcase'
import SpecialOffers from '../partials/SpecialOffers'

const Home = () => {
  return (
    <>
      <Header />
      <Showcase />
      <Collection title="Featured Products" />
      <SpecialOffers />
    </>
  )
}

export default Home