import './App.css'
import NavBar from './NavBar';
import GameInterface from './GameInterface';

function App() {
  return (
    <>
      <NavBar />
      <main className="container">
        <GameInterface />
      </main>
    </>
  )
}

export default App
