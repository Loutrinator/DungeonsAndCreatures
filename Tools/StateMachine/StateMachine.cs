using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

public partial class StateMachine : Node
{
    [Export]
    private State _initialState = null;

    private List<State> _states = null;
    private State _currentState = null;

    public override void _Ready()
    {
        base._Ready();
        _states = new List<State>();
        FetchAllStates();
        if(!InitializeCurrentState()){
            Debug.WriteLine("Error : could not find initial state");
            return;
        }
        LoadCurrentState();

    }

    private void FetchAllStates()
    {
        foreach (State child in FindChildren("*","State",false))
        {
                _states.Add(child);
        }
    }

    private bool InitializeCurrentState(){
        if(_initialState != null){
            _currentState = _initialState;
        }else if(_states.Count > 0) {
            _currentState = _states[0];
        }else{
            return false;
        }
        return true;
    }

    private void EnterState(State newState, State oldState){
    }
    private void ExitState(State oldState, State newState){
    }

    private void SetState(State newState){
        var previousState = _currentState;
        _currentState = newState;
        if(previousState != null){
            ExitState(previousState, newState);
        }
        if(newState != null){
            EnterState(newState, previousState);
        }
    }

}
